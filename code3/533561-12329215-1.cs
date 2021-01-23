    var typeToCheckTo = typeof(System.Drawing.Color);
    var type = typeof(System.Drawing.SystemColors);
    var fields = type.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).Where(p => p.PropertyType.Equals(typeToCheckTo));
    foreach (var field in fields)
    {
        Console.WriteLine(field.Name + field.GetValue(null, null));
    }
