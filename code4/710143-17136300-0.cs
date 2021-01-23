    public class ItemGroup
    {
        public int type;
    	
    	[XmlElement("Item")]
        public Item[] item;
    }
    
    public class Item
    {
        public string name;
        public int category;
    }
