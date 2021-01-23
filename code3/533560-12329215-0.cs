    var type = typeof(System.Drawing.Color);
    var fields = type.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
    foreach (var field in fields)
    {
        System.Drawing.Color color = (System.Drawing.Color)field.GetValue(null, null);
        Console.WriteLine(field.Name + " " + color);
    }
