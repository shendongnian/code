    StringBuilder outputDoc = new StringBuilder();
    
    // loop through the headers in the attributes
    // a struct which decomposes the information gleaned from the attributes
    List<OrderedProperties> orderedProperties = new List<OrderedProperties>();
    
    // get the properties for my object
    PropertyInfo[] props =
    	(typeof(PartsOrder)).GetProperties();
    
    // loop the properties
    foreach (PropertyInfo prop in props)
    {
    	// check for a custom attribute
    	if (prop.GetCustomAttributesData().Count() > 0)
    	{
    		foreach (object o in prop.GetCustomAttributes(false))
    		{
    			ExportOptionsAttribute exoa = o as ExportOptionsAttribute;
    
    			if (exoa != null)
    			{
    				orderedProperties.Add(new OrderedProperties() { OrderByValue = exoa.Order, PropertyName = prop.Name, Header = exoa.Header, Export = exoa.Export });
    			}
    		}
    	}
    }
    
    orderedProperties = orderedProperties.Where(op => op.Export == true).OrderBy(op => op.OrderByValue).ThenBy(op => op.PropertyName).ToList();
    
    foreach (var a in orderedProperties)
    {
    	outputDoc.AppendFormat("{0},", a.Header);
    }
    
    // remove the trailing commma and append a new line
    outputDoc.Remove(outputDoc.Length - 1, 1);
    outputDoc.AppendFormat("\n");
    
    
    var PartsOrderType = typeof(PartsOrder);
    
    //TODO: loop rows
    foreach (PartsOrder price in this.Orders)
    {
    	foreach (OrderedProperties op in orderedProperties)
    	{
    		// invokes the property on the object without knowing the name of the property
    		outputDoc.AppendFormat("{0},", PartsOrderType.InvokeMember(op.PropertyName, BindingFlags.GetProperty, null, price, null));
    	}
    
    	// remove the trailing comma and append a new line
    	outputDoc.Remove(outputDoc.Length - 1, 1);
    	outputDoc.AppendFormat("\n");
    }
