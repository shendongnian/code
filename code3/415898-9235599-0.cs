    public class IdText
    {
    	public IdText()
    	{
    	}
    	public IdText(int id, string text)
    	{
    		ID = id;
    		Text = text;
    	}
    
    	public int ID { get; set; }
    
    	public string Text { get; set; }
    
    }
    
    public class TCollection<T> : IEnumerable<T> where T : IdText, new()
    {
    
    	private List<T> list;
    
    	public TCollection()
    	{
    		list = new List<T>();
    	}
    
    	public void Add(int id, string text)
    	{
    		foreach (var item in list)
    		{
    			if (item.ID == id)
    			{
    				return;
    			}
    		}
    		list.Add(new T { ID = id, Text = text }); 
    	}
    }
