        public class Category1{
    	public string Name { get; set; }
    	
    	public virtual ICollection<Item> Items { get; set; }
    }
    
    public class Category2{
    	public string Name { get; set; }
    	
    	public Category1 ParentCategory { get; set; }
    	
    	public virtual ICollection<Item> Items { get; set; }
    }
    
    public class Item{
    	public string Name { get; set; }
    	public decimal Price { get; set; }
    }
