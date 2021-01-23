    foreach (var name in propertyNames)
    {
        // Or instance.GetType()
        var property = typeof(InventoryItem).GetProperty(name);
        Console.WriteLine("{0}: {1}", name, property.GetValue(instance, null));
    }
