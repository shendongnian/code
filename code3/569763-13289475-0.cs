      System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load("Settings.xml");
                if (xmlDoc.SelectNodes("/Clients/Client").Count <= 0)
                {
                    XElement newClient = new XElement("Client",
               new XElement("Name", cmbClient.Text),
               new XElement("Service",
                   new XElement("ServName", cmbService.Text)));
                    xmlDoc.Add(newClient);
                    xmlDoc.Save("Settings.xml");
                }
                else
                {
                    //find Service tag and add a new child element here
                }
