    public static IEnumerable<string> GetValidCategories(Animal a)
    {
        List<string> categories = new List<string>();
        if (a.MeatEater != null) categories.Add(a.MeatEater.Category);
        if (a.VegEater != null) categories.Add(a.VegEater.Catergory);
        return categories;
    }
