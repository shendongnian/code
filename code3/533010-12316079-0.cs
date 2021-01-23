    public class data
    {
    	public List<installation> installations { get; set; }
    	public data() { installations = new List<installation>(); }
    }
    
    public class installation
    {
    	[XmlElement("reader")]
    	public List<reader> reader { get; set; }
    	public installation() { reader = new List<reader>(); }
    }
    
    public class reader
    {
    	[XmlTextAttribute]
    	public Int32 value {get;set;}
    }
