    ...   
            // Get model to validate inside class scope 
            object instance;  // <--- will hold the model instance
            var modelProperty = GetModelToValidateInClassScope(Attrib, method, out instance); 
 
            if (modelProperty != null) 
            { 
                ValidateModel(instance, modelProperty); // <--- make sure to pass the instance along!
            } 
    ...
    protected virtual void ValidateModel(object instance, PropertyInfo modelProperty)         
    {         
        var model = modelProperty.GetValue(instance, null);    <--- get value of instance property
        ...
        
    }     
