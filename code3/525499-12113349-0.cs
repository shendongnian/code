    [XmlIgnore]
    public int GroupID 
    {
        get { !string.IsNullOrEmpty(GroupAsText) ? int.Parse(GroupAsText) : 0; }
        set { GroupID = value; }
    }
    
    [XmlAttribute("GroupID")
    public int GroupIDAsText { get; set; }
