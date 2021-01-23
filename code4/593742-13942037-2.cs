    public class Hero
    {
    	public int state {get; set; }
    	public int x { get; set; }
    	public int y { get; set; }
    	public string path { get; set; }
    	
    	[XmlIgnore]
    	public Image img { get; set; }
    }
