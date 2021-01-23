    foreach (Type type in types)      
    {          
        var typeIShellViewInterface = type.GetInterface(_NamespaceIShellView, false);          
        if (typeIShellViewInterface != null)          
        {              
            try
            {
                // I assume you are calling this line at the point marked 'here'. 
                // To debug the creation wrap in a try-catch and view the inner exceptions
                var result = Activator.CreateInstance(type);          
            }
            catch(Exception caught)
            {
                // When you hit this line, look at caught inner exceptions
                // I suspect you have a broken Xaml file inside WPF usercontrol
                // or Xaml resource dictionary used by type
                Debugger.Break();
            }
        }      
    }  
