    void ValidateAndSet(string propName, object newValue){
        foreach(var prop in propsClass.GetType().GetProperties().Where(p => p.Name == propName))
        {
            if(CommonValidate(prop, newValue))
                prop.GetSetMethod().Invoke(propsClass, new object[] { newValue});
            return; // Only one anyways
        }
        Logger.Log("Failed to find the property '{0}' to set '{1}'", propName, newValue);
    }
