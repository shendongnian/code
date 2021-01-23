I got this code to end up with the value of x being "OtroID Maps to CityID".
    var props = typeof(City).GetProperties();
    foreach (var prop in props)
    {
        var attributes = Attribute.GetCustomAttributes(prop);
        foreach (var attribute in attributes)
        {
            if (attribute is ColumnName)
            {
                ColumnName a = (ColumnName)attribute;
                var x = string.Format("{1} Maps to {0}",prop.Name,a.ColumnMapName);
            }
        }
    }
