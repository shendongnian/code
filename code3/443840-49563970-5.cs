    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Allow WebApi to Use a Custom Parameter Binding
            config.ParameterBindingRules.Add(descriptor => descriptor.ParameterType == typeof(int[])
                                                               ? new CommaDelimitedArrayParameterBinder(descriptor)
                                                               : null);
            // Allow ApiExplorer to understand this type (Swagger uses ApiExplorer under the hood)
            TypeDescriptor.AddAttributes(typeof(int[]), new TypeConverterAttribute(typeof(StringToIntArrayConverter)));
            // Any existing Code ..
        }
    }
