    public static void EditConfiguration (DesignConfiguration design)
    {
        XDocument configXml = XDocument.Load(configXMLFileName);
        var updateData = configXml.Root.Elements("Design").Where(element => (String)element.Attribute("name") == design.DesignName).FirstOrDefault();
        if (updateData != null)
        {
            var myElements = updateData.Elements();  //All the elements under th Design node 
            myElements.Remove();
            updateData.SetElementValue("SourceFolder", design.SourceFolder);
            updateData.SetElementValue("DestinationFolder", design.DestinationFolder);
            updateData.SetElementValue("CopyLookups", design.CopyLookups);
            configXml.Save(configXMLFileName);
       }            
    }
