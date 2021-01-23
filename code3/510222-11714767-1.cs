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
            XElement x = XElement.Parse(s.ToString());
            Dictionary<string, string> d = x.Element("FiledMappings").Elements("Field").ToDictionary(e => e.Attribute("Name").Value, e => e.Element("DataSource").Value);
            foreach (KeyValuePair<string, string> p in d)
                Console.WriteLine(string.Format("{0}:\t{1}", p.Key, p.Value));
            Console.ReadLine();
        }
