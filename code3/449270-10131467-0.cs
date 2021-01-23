    [XmlElement("Items")]
    public MyBase[] Items
    {
        get
        {
            return items.Where(item => item.GetType() == typeof(MyBase)).ToArray();
        }
        set 
        {
            items = new HashSet<MyBase>(value);
        }
    }
