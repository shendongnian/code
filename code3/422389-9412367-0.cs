    [Serializable]
    public class MenuItem
    {
    	public int Id { get; set; }
    	public string MenuText { get; set; }
    	public string MenuUrl { get; set; }
    	public string ImageUrl { get; set; }
    
    	public List<MenuItem> Children { get; set; }
    
    	public MenuItem(int id, string text, string url)
    		: this(id, text, url, String.Empty)
    	{
    	}
    
    	public MenuItem(int id, string text, string url, string imageUrl)
    	{
    		this.Id = id;
    		this.MenuText = text;
    		this.MenuUrl = url;
    		this.ImageUrl = imageUrl;
    
    		this.Children = new List<MenuItem>();
    	}
    }
