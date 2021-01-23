    public class Folder
    {
    	public Folder()
    	{
    		Folders = new List<Folder>();
    		Files = new List<File>();
    	}
    
    	public string Name { get; set; }
    	public ICollection<Folder> Folders { get; set; }
    	public ICollection<File> Files { get; set; }
    
    	public IEnumerable Items
    	{
    		get
    		{
    			var items = new CompositeCollection();
    			items.Add(new CollectionContainer { Collection = Folders });
    			items.Add(new CollectionContainer { Collection = Files });
    			return items;
    		}
    	}
    }
