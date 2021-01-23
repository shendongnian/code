    public class myItem
    {
        public long Key { get; set; }
        public double Discount { get; set; }
    }
    
    public class myList
    {
    	[XmlElement]
        public List<myItem> myItem { get; set; }
    }
