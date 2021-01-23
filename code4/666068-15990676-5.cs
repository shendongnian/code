    public static IEnumerable<object> 
        SelectAsEnumerable(this IQueryable entitySet, params string[] propertyPath)
    {
        return entitySet.SelectDynamic(propertyPath) as IEnumerable<object>;
    }
    var list = db.YourEntity.SelectAsEnumerable("Name", "ID", "TestProperty.ID").ToList();
