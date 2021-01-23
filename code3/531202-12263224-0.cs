    Type newObjectType = orgObject.GetType();
    object newObject = Activator.CreateInstance(newObjectType);
    
    foreach (var propInfo in orgObject.GetType().GetProperties())
    {
    	object orgValue = propInfo.GetValue(orgObject, null);
    	
    	// set the value of the new object
    	propInfo.SetValue(newObject, orgValue, null);
    }
