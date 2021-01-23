    foreach (var prop in this.GetType().GetProperties())
    {
         if (prop.PropertyType.IsClass)
         {
             object instance = Activator.CreateInstance(prop.PropertyType);
             // Step 2: ???
             // Step 3: Profit!
         }
    }
