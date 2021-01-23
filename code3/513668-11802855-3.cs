    public static List<TObject> SortForMe<TObject, TProperty>(
        this List<TObject> list, 
        Expression<Func<TObject, TProperty>> property, 
        SortDirection sortDirection)
    {
         string propertyName = GetPropertyName(property);
         ...
         ...          
         // when casting compiled expression to Func, instead of object, use TProperty
         // that way, you will avoid boxing
         var result = list.OrderBy((Func<T, TProperty>)e1.Compile()).ToList();
         ...
         ...
    }
