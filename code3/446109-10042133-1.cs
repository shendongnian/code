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
    	public string GWT_ { get; set; }
    	public string ALT_ { get; set; }
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
