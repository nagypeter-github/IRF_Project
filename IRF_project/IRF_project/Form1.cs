using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LumenWorks.Framework.IO.Csv;

namespace IRF_project
{
    public partial class Form1 : Form
    {
        List<Adat> adats = new List<Adat>();
        
        public Form1()
        {
            InitializeComponent();
           adats = GetAdat(@"C:\Temp\adat.csv");


        }
        public List<Adat> GetAdat(string csvpath)
        {
            List<Adat> adats = new List<Adat>();
            using (StreamReader sr = new StreamReader("adat.csv", Encoding.Default))
            {
               while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');
                    adats.Add(new Adat()
                    {
                        szam1 = int.Parse(line[0]),
                        szam2 = int.Parse(line[1])
                    });
               
                }
            }

            return adats;
        }
       


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.DataSource = adats;
            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Bar;
            series.XValueMember = "adat1";
            series.YValueMembers = "adat2";
            series.BorderWidth = 2;




        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void adatBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private static FileStream fs = new FileStream(@"c:\temp\mcb.txt", FileMode.OpenOrCreate, FileAccess.Write);
        private static StreamWriter m_streamWriter = new StreamWriter(fs);

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_streamWriter.WriteLine("{0} {1}",
            DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
