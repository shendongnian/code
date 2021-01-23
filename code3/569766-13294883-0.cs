        XDocument xDoc = XDocument.Load("Settings.xml");
        var Clients =
            from client in xDoc.Root.Elements("Client")
            where client.Element("Name").Value == cmbClient.Text
            select client;
        if (Clients.Count() > 0)
        {
            var Client =
                (from client in xDoc.Root.Elements("Client")
                where client.Element("Name").Value == cmbClient.Text
                select client).Single();
            if (Client.Elements("Services").Count() == 0)
            {
                Client.Add(
                    new XElement("Services",
                        new XElement("Service", cmbService.Text)));
            }
        }
        else
        {
            XElement newClient = new XElement("Client",
                new XElement("Name", cmbClient.Text),
                new XElement("Services",
                    new XElement("ServName", cmbService.Text)));
            xDoc.Root.Add(newClient);
        }
        xDoc.Save("Settings.xml");
