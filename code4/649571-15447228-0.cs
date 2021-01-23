    public class Something
    {
    	public int Id { get; set; }
    
    	public string Text { get; set; }
    
    	public IEnumerable<string> Colors { get; set; }
    }
    
    public class MySerializableSomething : Something, IXmlSerializable
    {
    	public new List<string> Colors { get; set; }
    
    	public MySerializableSomething()
    	{
    		Colors = new List<string>();
    	}
    
    	public XmlSchema GetSchema()
    	{
    		return null;
    	}
    
    	public void ReadXml(XmlReader reader)
    	{
    		while (reader.Read())
    		{
    			switch (reader.LocalName)
    			{
    				case "Id": Id = reader.ReadElementContentAsInt(); break;
    				case "Text": Text = reader.ReadElementContentAsString(); break;
    				case "Color": Colors.Add(reader.ReadElementContentAsString()); break;
    			}
    		}
    	}
    
    	public void WriteXml(XmlWriter writer)
    	{
    		writer.WriteElementString("Id", Id.ToString());
    		writer.WriteElementString("Text", Text);
    
    		writer.WriteStartElement("Colors");
    
    		foreach (var color in Colors)
    		{
    			writer.WriteElementString("Color", color);
    		}
    
    		writer.WriteEndElement();
    	}
    }
