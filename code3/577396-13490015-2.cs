    public static class AnonymousExtensions
    {
        public static T To<T>(this object anon)
        {
            // #1 Obtain the type implementing the whole interface
            Type implementation = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .SingleOrDefault(t => t.GetInterfaces().Contains(typeof(T)));
    
            // #2 Once you've the implementation type, you create an instance of it
            object implementationInstance = Activator.CreateInstance(implementation, false);
    
            // #3 Now's time to set the implementation properties based on
            // the anonyous type instance property values!
            foreach(PropertyInfo property in anon.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                // Has the implementation this anonymous type property?
                if(implementation.GetProperty(property.Name) != null)
                {
                    // Setting the implementation instance property with the anonymous
                    // type instance property's value!
                    implementation.GetProperty(property.Name).SetValue(implementationInstance, property.GetValue(anon, null));
                }
            }
    
            return (T)implementationInstance;
        }
    }
