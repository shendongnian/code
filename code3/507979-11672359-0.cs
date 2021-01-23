    public class MyDynamicTypeConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
			if (destinationType.Equals(typeof(string)))
			{
				BaseDataType baseDisplay = GetBaseDisplay(context);
				if (baseDisplay.ReadFailed)
				{
					// Display the error message
					return baseDisplay.ErrorMessageReadFailed;
				}
			}
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
			BaseDataType baseDisplay = GetBaseDisplay(context);
			if (baseDisplay.ReadFailed)
			{
				// If read failed, do not expand the display for this object
				return false;
			}
            return base.GetPropertiesSupported(context);
        }
        private BaseDataType GetBaseDisplay(ITypeDescriptorContext context)
        {
            // Extract base data type using reflections
            object obj = context.Instance.GetType().GetProperty(context.PropertyDescriptor.Name).GetValue(context.Instance, null);
            return (BaseDataType)obj;
        }
    }
