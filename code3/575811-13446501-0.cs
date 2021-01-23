    public class FormatterModelBinder : DefaultModelBinder
    {
        internal static string TrimValue([CanBeNull] string value, [CanBeNull] FormatAttribute formatter)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return ((formatter == null) || formatter.Trim) ? value.Trim() : value;
        }
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
        {
            if ((propertyDescriptor != null) && (propertyDescriptor.PropertyType == typeof(string)))
            {
                var stringValue = value as string;
                var formatter = propertyDescriptor.Attributes.OfType<FormatAttribute>().FirstOrDefault();
                stringValue = TrimValue(stringValue, formatter);
                value = stringValue;
            }
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
