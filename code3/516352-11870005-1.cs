    using (WebClient client = new WebClient())
    {
        // Set credentials...   
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(client.DownloadString("<YOUR_URL>"));
        // Select the Identifier node with a 'name' attribute having an 'id' value
        var node = doc.DocumentElement.SelectSingleNode("//Identifier[@name='id']");
        if (node != null && node.Attributes["value"] != null)
        {
            // Pick out the 'value' attribute's value
            var val = node.Attributes["value"].Value;
            // ...
        }
    }
