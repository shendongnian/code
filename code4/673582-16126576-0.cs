        string typeName = "BlueprintsManager.WorkingStandardBlueprint";
        string propertyName = "MyProperty";
        
        var type = Assembly.GetExecutingAssembly().GetType(typeName);
        var property = type.GetProperty(propertyName);
        object first = class_array[0];
        // Getter:
        int result = (int)property.GetMethod.Invoke(first, null);
        // Setter
        property.SetMethod.Invoke(first, new object[] { 10 });
        
