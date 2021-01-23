    public class Item
    {
    	[XmlAttribute("id")]
    	public int Id { get ;set; }
    	
    	[XmlText]
    	public string Name { get; set; }
    }
    
    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("item")]
    	public Item[] Items { get;set;}
    }
