    public class Answer : IXmlSerializable
    {
    	public List<string> list = new List<string>();
    	public string this[int pos]
    	{
    		get
    		{
    			return list[pos];
    		}
    		set
    		{
    			list[pos] = value;
    		}
    	}
    	
    	public void ReadXml ( XmlReader reader )
    	{
    		reader.ReadToDescendant("a");
    		while ( reader.Name != "Answers" )
    		{
    			if ( reader.IsStartElement() )
    			{
    				list.Add(reader.ReadElementContentAsString());
    			}
    		}
    		reader.Read();
    	}
    	
    	public void WriteXml ( XmlWriter writer )
    	{
    		for ( int i = 0; i < list.Count; i++ )
    		{
    			writer.WriteElementString(((char)(97 + i)).ToString(), list[i]);
    		}
    	}
    	
    	public XmlSchema GetSchema()
    	{
    		return(null);
    	}
    }
