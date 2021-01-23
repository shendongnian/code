    class ResourceConverter : IValueConverter
    {
        public ResourceManager ResourceManager { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ResourceManager == null)
                throw new InvalidOperationException("The resource manager is not set");
            
            if (value == null)
                return string.Empty;
            string prefix = parameter as string ?? string.Empty;
            string resourceKey = prefix + value;
            if (string.IsNullOrEmpty(resourceKey))
                return string.Empty;
            return ResourceManager.GetString(resourceKey);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
