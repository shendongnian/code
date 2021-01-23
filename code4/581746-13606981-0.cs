    public static class AutofacExtensions
    {
        public void RegisterCustomClasses<T>(this ContainerBuilder builder)
        {
            var methods = typeof(T).GetMethods();
            var attributes = methods.Select(x => new
                                            {
                                                Method = x,
                                                Attribute = GetAttribute(x)
                                            })
                                    .Where(x => x.Attribute != null);
    
            foreach(var data in attributeData)
                builder.RegisterInstance(new CustomClass(data.Attribute.Caption, 
                                                         data.Method));
        }
        private static NewCustomActionAttribute GetAttribute(MethodInfo method)
        {
            return method.GetCustomAttributes(typeof(NewCustomActionAttribute))
                         .OfType<NewCustomActionAttribute>()
                         .FirstOrDefault()
        }
    }
