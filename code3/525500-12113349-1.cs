    [XmlIgnore]
    public int GroupID 
    {
        get { !string.IsNullOrEmpty(GroupIDAsText) ? int.Parse(GroupIDAsText) : 0; }
        set { GroupID = value; }
    }
    
    [XmlAttribute("GroupID")
    public int GroupIDAsText { get; set; }
        
.
