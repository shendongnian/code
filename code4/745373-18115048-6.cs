    public static class ModelExtensionMethods
    {
        public static string ViewModelPropertyName(this object obj, string name)
        {
            var attributes = obj.GetType()
                                .GetCustomAttributes()
                                .First()
                                .GetType()
                                .GetProperty(name)
                                .GetCustomAttributes();
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
