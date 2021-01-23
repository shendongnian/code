    using (XmlWriter writer = XmlWriter.Create("new.xml"))
    {
            writer.WriteStartDocument();
    	    writer.WriteStartElement("StatusList");
    	    writer.WriteElementString("Status", "Success");   // <-- These are new
            writer.WriteEndDocument();
    }
