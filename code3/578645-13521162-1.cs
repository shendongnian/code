    private void DoSomethingWithFields<T>(T obj)
    {
        // Go through all fields of the type.
        foreach (var field in typeof(T).GetFields())
        {
            var fieldValue = field.GetValue(obj);
            // You would probably need to do a null check
            // somewhere to avoid a NullReferenceException.
            // Check if this is a list/array
            if (typeof(IList).IsAssignableFrom(field.FieldType))
            {
                // By now, we know that this is assignable from IList, so we can safely cast it.
                foreach (var item in fieldValue as IList)
                {
                    // Do you want to know the item type?
                    var itemType = item.GetType();
                    // Do what you want with the items.
                }
            }
            else
            {
                // This is not a list, do something with value
            }
        }
    }
