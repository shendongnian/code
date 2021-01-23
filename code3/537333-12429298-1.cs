    public List<The type of your list items> List { get; set; }
    
    public List<The type of your list items> SortedByX 
    {
        get
        {
            return List.Sort(iComparer);
        }
    }
    // Or using LINQ
    public List<The type of your list items> SortedByY 
    {
        get
        {
            return List.OrderBy....
        }
    }
