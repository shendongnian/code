    public void Save()
    {
          XmlDocument doc = new XmlDocument();
          XmlNode XmlNodeJob = doc.CreateElement("Job");
          doc.AppendChild(XmlNodeJob);
          OtherclassSave2(XmlNodeJob);
     }
    
    public void OtherclassSave2(IXPathNavigable node)
    {
    	// Deal with node using the interface only
    }
