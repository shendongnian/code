    void Main()
    {
    	using(var stream = File.Open(@"test.xml", FileMode.Open))
    	{
    		var serializer = new XmlSerializer(typeof(Root));
    		
    		var root = (Root)serializer.Deserialize(stream);
    		
    		root.Dump();
    	}
    }
    
    public class Package
    {
    	[XmlElement("GWT_0")]
    	public string GWT_ { get; set; }
    
    	[XmlElement("ALT_0")]
    	public string ALT_ { get; set; }
    
    	[XmlElement("SAT__0")]
    	public string SAT__ { get; set; }
    }
    
    public class Data
    {
        [XmlElement("Package")]
    	public Package[] Package { get; set; }
    }
    
    public class Root
    {
    	public Data Data{get;set;}
    }
