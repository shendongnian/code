            StringBuilder s = new StringBuilder();
            s.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            s.AppendLine("<Integration>");
            s.AppendLine("<FiledMappings name =\"Employee\">");
            s.AppendLine("<Field Name=\"EmployeeID\">");
            s.AppendLine("<DataSource>EmployeeNO</DataSource>");
            s.AppendLine("</Field>");
            s.AppendLine("<Field Name=\"Department\">");
            s.AppendLine("<DataSource>Department</DataSource>");
            s.AppendLine("</Field>");
            s.AppendLine("<Field Name=\"EmployeeName\">");
            s.AppendLine("<DataSource>Name</DataSource>");
            s.AppendLine("</Field>");
            s.AppendLine("</FiledMappings>");
            s.AppendLine("</Integration>");
                        
            Dictionary<string, string> d = new Dictionary<string, string>();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s.ToString());
            
            XmlNode x = doc.ChildNodes[1].ChildNodes[0];
            foreach (XmlNode n in x.ChildNodes)
                d[n.Attributes[0].Value] = n.FirstChild.FirstChild.Value;
            foreach (KeyValuePair<string, string> p in d)
                Console.WriteLine(string.Format("{0}:\t{1}", p.Key, p.Value));
            Console.ReadLine();
