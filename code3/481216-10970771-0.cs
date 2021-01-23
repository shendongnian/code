    private Dictionary<int, string> relatedProducts { set; get;}
    public Dictionary<int, string> relatedProductsList { 
            get {return relatedProducts; } 
        }
    
    public GenericLists()
    {
            relatedProducts = new Dictionary<int, string>
                {
                        {0, "CTRL + Click to select multiples"},
                        {1, "A"},
                        {2, "B"},
                        {3, "C"},
                        {4, "D"},
                 };
    }
