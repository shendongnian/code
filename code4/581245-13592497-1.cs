    var attributes = 
        // Get all public properties, you might want to
        // call a more specific overload based on your needs.
        from p in obj.GetType().GetProperties()
        // Get the attribute.
        let attribute = p.GetCustomAttributes<GridColumnAttribute>().
            // Assuming allow multiple is false.
            SingleOrDefault().
        // Filter out null properties.
        where attribute != null
        // Map property with attribute.
        select new { Property = p, Attribute = attribute };
