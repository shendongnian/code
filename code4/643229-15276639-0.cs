    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value is Image && destinationType.Equals(typeof(string)))
            {
                return "Text to replace System.Drawing.Bitmap";
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
