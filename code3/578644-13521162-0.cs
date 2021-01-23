    private void DoSomethingWithFields(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields();
        foreach (var field in fields)
        {
            var fieldValue = field.GetValue(obj);
            // You would probably need to do a null check
            // somewhere to avoid a NullReferenceException.
            // Check if this is a list/array
            if (typeof(IList).IsAssignableFrom(field.FieldType))
            {
                // By now, we know that this is assignable from IList, so we can safely cast it.
                IList list = fieldValue as IList;
                foreach (var item in list)
                {
                    // Do you want to know the item type?
                    Type itemType = item.GetType();
                    // Do what you want with the items.
                }
            }
            else
            {
                // This is not a list, do something with value
            }
        }
    }
