    internal sealed class CustomAttribute : Attribute
    {
        public CustomAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    
        public string PropertyName { get; set; }
    
        public string ErrorMessage { get; set; }
    
        public static void ThrowIfNotEquals(object obj, PropertyChangedEventArgs eventArgs)
        {
            Type type = obj.GetType();
            var changedProperty = type.GetProperty(eventArgs.PropertyName);
            
            var attribute = (CustomAttribute)changedProperty
                .GetCustomAttributes(typeof(CustomAttribute), false)
                .FirstOrDefault();
    
            var valueToCompare = type.GetProperty(attribute.PropertyName).GetValue(obj, null);
            if (!valueToCompare.Equals(changedProperty.GetValue(obj, null)))
                throw new Exception("the source and destination should not be equal");
        }
    }
