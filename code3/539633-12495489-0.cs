    public static void Retion(Type type)
    {
        using (DataContext entitiesContext = 
            (DataContext)Activator.CreateInstance(type))
        {...}
