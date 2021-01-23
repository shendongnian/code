        // Using reflection.
        MethodInfo method = typeof(ClassName).GetMethod("Get");
        Attribute[] attributes = Attribute.GetCustomAttributes(method, typeof(UserAccess), true);
        // Displaying output. 
        foreach (var attr in attributes)
        {
            if (attr is UserAccess)
            {
                var ua = (UserAccess)attr;
                System.Console.WriteLine("{0}",a.userRole);
            }
        }
