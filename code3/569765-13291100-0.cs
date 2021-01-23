    if (xmlDoc.Elements("Client").Count() == 0)
    {
        //Client section does not exist. We add new section.
        XElement newClient = new XElement("Client",
            new XElement("Name", mbClient.Text),
            new XElement("Service",
        new XElement("ServName", cmbService.Text)));
        xmlDoc.Add(newClient);
    }
    else //Client section exists.
    {
        //obtain <service> section
        XElement service = xmlDoc.Element("Client").Element("Service");
       
        if (service.Elements().Count(el => el.Value == cmbService.Text) == 0)
        { 
            //there is no service with name cmbService.Text. We add one.
            service.Add(new XElement("ServName", cmbService.Text));
        }
    }
