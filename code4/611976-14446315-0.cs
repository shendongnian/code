    var namespaces = Assembly.GetExecutingAssembly().GetTypes()
                             .Select(t => t.Namespace)
                             .Distinct();
    
    //Returns:
    //  WindowsFormsApplication2
    //  WindowsFormsApplication2.Properties
