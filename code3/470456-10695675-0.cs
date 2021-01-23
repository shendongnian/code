    var fieldValues = test.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            
    foreach(var fieldValue in fieldValues)
    {
        if (fieldValue.FieldType.IsGenericType && fieldValue.FieldType.GetGenericTypeDefinition() == typeof(List<>))
        {
            fieldValue.SetValue(test, new List<string>()
            {
                "List Item 1",
                "List Item 2"
            });
        }
    }
