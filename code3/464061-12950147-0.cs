    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Web;
    using System.Net;
    using HtmlAgilityPack;
    
    
    
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            private DataTable dt;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string htmlCode = "";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "AvoidError");
                    htmlCode = client.DownloadString("http://www.info.gov.za/aboutsa/holidays.htm");
                }
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    
                doc.LoadHtml(htmlCode);
    
                dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(string));
    
                int count = 0;
          
           
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                {
                    
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                      
                        if (table.Id == "table2")
                        {
                            DataRow dr = dt.NewRow();
    
                            foreach (var cell in row.SelectNodes("td"))
                            {
                                if ((count % 2 == 0))
                                {
                                    dr["Name"] = cell.InnerText.Replace("&nbsp;", " ");
                                }
                                else
                                {
                                  
                                    dr["Value"] = cell.InnerText.Replace("&nbsp;", " ");
    
                                    dt.Rows.Add(dr);
                                }
                                count++;
    
                            }
    
    
                        }
    
                    }
    
    
                    dataGridView1.DataSource = dt;
    
                }
            }
    
        }
    }![Screenshot  at run time][2]
