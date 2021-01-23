    public static bool AddObject(this IObject obj)
    {
        return DataProvider.InsertObject((dynamic)obj, DataProvider.GetConnection());
    }
    
