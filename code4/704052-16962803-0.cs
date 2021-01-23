    private void TrySetProperty(object obj, string property, object value)
    {
         var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
         if (prop != null)
             prop.SetValue(obj, value,    
    }
