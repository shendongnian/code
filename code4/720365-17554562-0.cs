            XmlDocument log = new XmlDocument();
            log.Load(@"C:\Users\barranca\Desktop\test.xml");
           // XmlNodeList xml = log.SelectNodes("//ns1:Alerts");
            var name = new XmlNamespaceManager(log.NameTable);
            name.AddNamespace("ns1", "Microsoft.SystemCenter.DataWarehouse.Report.Alert");
            XmlNodeList xml = log.SelectNodes("//ns1:Alert", name);
            
            foreach (XmlNode alert in xml)
            {
                Console.Write("HERE");
                XmlNode test = alert.SelectSingleNode("//ns1:AlertName",name);
                string testing = test.InnerText;
                Console.Write(testing);
            }
