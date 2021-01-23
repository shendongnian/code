    public static class ModelExtensionMethods
    {
        public static string ViewModelPropertyName(this object obj, string name)
        {
            var attributes = obj.GetType()
                                .GetCustomAttributes(true)
                                .OfType<MetadataTypeAttribute>()
                                .First()
                                .MetadataClassType 
                                .GetProperty(name)
                                .GetCustomAttributes(true);
            if (attributes.OfType<ViewModelPropertyNameAttribute>().Any())
            {
                return attributes.OfType<ViewModelPropertyNameAttribute>()
                                 .First()
                                 .GetViewModelPropertyName();
            }
            else
            {
                return name;
            } 
        }
    }
