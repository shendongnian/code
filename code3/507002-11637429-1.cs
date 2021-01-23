    var type = typeof(Customer);
    foreach (var prop in type.GetProperties())
    {
        var attribute = Attribute.GetCustomAttribute(prop, typeof(ShowAttribute)) as ShowAttribute;
        if (attribute != null)
        {
            Console.WriteLine(attribute.Name);
        }
    }
