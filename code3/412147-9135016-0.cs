    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                LoadCSV();
            }
    
            private void LoadCSV()
            {
                List<string> Rows = new List<string>();
                string m_CSVFilePath = "<Path to CSV File>";
    
                using (StreamReader r = new StreamReader(m_CSVFilePath))
                {
                    string row;
    
                    while ((row = r.ReadLine()) != null)
                    {
                        Rows.Add(row.Replace("\"", ""));
                    }
    
                    foreach (var Row in Rows)
                    {
                        if (Row.Length > 0)
                        {
                            string[] RowValue = Row.Split(',');
    
                            //Do something with values here
                        }
                    }
                }
            }
        
        }
    }
