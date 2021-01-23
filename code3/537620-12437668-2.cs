    MyClass myClass = new MyClass();
    MethodInfo[] methods =  myClass.GetType().GetMethods(); // Access all the public methods.
            foreach (var methodInfo in methods) // iterate trough all methods.
            {
              
                 // Get all custom attributes from the method.
                 object[] attributes =  methodInfo.GetCustomAttributes(typeof (CustomRoleAttribute), true); 
                            
                if (attributes.Length > 0)
                {
                    CustomRoleAttribute attribute = (CustomRoleAttribute)attributes[0];
                    if (attribute.Role == "Admin")
                    {
                         // the role is admin
                    }
                 }
            }
