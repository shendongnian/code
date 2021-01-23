    public static IEnumerable<T> SelectNonNull<T>(
        this IEnumerable<T> source,
        string propertyName)
    {
        PropertyInfo variable = typeof(T).GetProperty(propertyName);
        if (variable == null)
        {
            // Specified property does not exist on this item type:
            //just return all items
            return from item in source
                    select item;
        }
        else
        {
            return from item in source
                    where variable.GetValue(item, null) != null
                    select item;
        }
    }
