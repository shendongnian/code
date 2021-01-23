    public class BrickTable
    {
    	public int		Value	{ get; set; }
    	public string	Title	{ get; set; }
    	public int		X		{ get; set; }
    	public int		Y		{ get; set; }
    
    	[XmlArrayItem("ItemType")]
    	public List<string> Items	{ get; set; }
    	
    	public BrickTable()
    	{
    	}
    }
