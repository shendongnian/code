    public Dictionary<string, decimal> SpendingCategories { get; private set; }
    
    public SpendingCategoriesViewModel()
    {
        SpendingCategories = new Dictionary<string,decimal>
        {   
            {"Petrol", 120.5m},
            {"Rent", 400},
            {"Food", 200}
        };
    }
