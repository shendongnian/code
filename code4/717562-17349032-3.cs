    // This will iterate over the objects within your model
    foreach( object l_item in model )
    {
        // This will discover the properties for each item in your model:
        var l_itemProperties = l_item.GetType().GetProperties();
        foreach ( PropertyInfo l_itemProperty in l_itemProperties )
        {
            var l_propertyName = l_itemProperty.Name;
            var l_propertyValue = l_itemProperty.GetValue( l_item, null );
        }
        // ...OR...
        // This will get a specific property value for the current item:
        var l_columnValue = ((dynamic) l_item).Column;
        // ... of course, this will fail at run-time if your item does not
        // have a Column property, unlike the foreach loop above which will
        // simply process all properties, whatever their names
    }
