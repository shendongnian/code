    var actionDescriptors = new ReflectedControllerDescriptor(GetType())
      .GetCanonicalActions();
    foreach(var action in actionDescriptors)
    {
       object[] attributes = action.GetCustomAttributes(false);
       
       // if you want to get your custom attribute only
       var t4Attributes = action.GetCustomAttributes(false)
        .Where(a => a is T4ValidateAttribute).ToList();
       
    }
