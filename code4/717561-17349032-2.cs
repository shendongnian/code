    IEnumerable<PropertyInfo> l_properties = model.GetType().GetProperties();
    var l_customObjects = l_properties.Select( 
            (p, i) =>
                new { 
                    item = p, /* This is the PropertyInfo object */
                    Index = i /* This is the index of the PropertyInfo 
                                 object within l_properties */
                }
        )
    foreach ( var indexedItem in l_customObjects )
    {
        // ...
    }
