    public class Path : ConfigurationElement
    {
    	[ConfigurationProperty("name", IsRequired = true)]
    	public string Name
    	{
    		get
    		{
    			return (string)this["name"];
    		}
    	}
    
    	[ConfigurationProperty("permission", IsRequired = true)]
    	public string Permission
    	{
    		get
    		{
    			return (string)this["permission"];
    		}
    	}
    }
    
    public class Paths : ConfigurationElementCollection
    {
    	public Path this[int index]
    	{
    		get
    		{
    			return BaseGet(index) as Path;
    		}
    		set
    		{
    			if (BaseGet(index) != null)
    			{
    				BaseRemoveAt(index);
    			}
    			BaseAdd(index, value);
    		}
    	}
    
    	protected override ConfigurationElement CreateNewElement()
    	{
    		return new Path();
    	}
    	protected override object GetElementKey(ConfigurationElement element)
    	{
    		return ((Path)element).Name;
    	}
    }
    
    public class DiskConfigSection : ConfigurationSection
    {
    	public static DiskConfigSection GetConfig()
    	{
    		var b = ConfigurationManager.GetSection("Disk") != null;
    		return b ? (DiskConfigSection)ConfigurationManager.GetSection("Disk") : new DiskConfigSection();
    	}
    
    	[ConfigurationProperty("Paths")]
    	[ConfigurationCollection(typeof(Paths), AddItemName = "Path")]
    	public Paths Paths
    	{
    		get
    		{
    			var o = this["Paths"];
    			return o as Paths;
    		}
    	}
    }
