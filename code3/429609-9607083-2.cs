    private bool hasChanges(object OldObject, object newObject)  
        {  
            var oldprops = OldObject.GetType().GetProperties();  
            var newprops = newObject.GetType().GetProperties();
            var joinedProps = from oldProp in oldprops
                              join newProp in newProps
                                  on oldProp.Name equals newProp.Name
                              select new { oldProp, newProp }
            foreach (var pair in joinedProps)  
            {  
                if (checkColumnNames(pair.oldProp.Name))  
                {  
                    var oldVal = pair.oldProp.GetValue(OldObject, null);  
                    var newVal = pair.newProp.GetValue(newObject, null);  
  
    //etcetera
