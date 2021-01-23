    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("videotitle");
                dt.Columns.Add("link");
                dt.Columns.Add("thumb");
    
                for (int i = 0, j = 5; i <= j; i++)
                {
                    var row = dt.NewRow();
                    row["name"] = string.Format("video {0}", i);
                    row["videotitle"] = string.Format("video {0}", i);
                    row["link"] = string.Format("/someurl/video{0}.avi", i);
                    row["thumb"] = string.Format("/someurl/video{0}.png", i);
                    dt.Rows.Add(row);
                }
                var xmlDoc = CreatePlaylist(dt);
    
                Console.WriteLine(XDocToStringWithDeclaration(xmlDoc));
    
    
                Console.WriteLine("{0}Finished... Press a key", Environment.NewLine);
                Console.ReadKey();
    
            }
    
            public static string XDocToStringWithDeclaration(XDocument doc)
            {
                string xString;
                using (var sw = new System.IO.MemoryStream())
                {
                    using (var strw = new System.IO.StreamWriter(sw, System.Text.UTF8Encoding.UTF8))
                    {
                        doc.Save(strw);
                        xString = System.Text.UTF8Encoding.UTF8.GetString(sw.ToArray());
                    }
                }
                return xString;
            }
    
            public static XDocument CreatePlaylist(System.Data.DataTable DataTable)
            {
                var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var xItem = new XElement("item");
                foreach (var row in DataTable.Rows.OfType<System.Data.DataRow>())
                    xItem.Add(new XElement("list",
                                new XAttribute("name", row["name"].ToString()),
                                new XAttribute("videotitle", row["videotitle"].ToString()),
                                new XAttribute("link", row["link"].ToString()),
                                new XElement("thumb", row["thumb"].ToString())));
                xDoc.Add(xItem);
                return xDoc;
            }
        }
    }
