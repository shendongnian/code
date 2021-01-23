	class FilePathConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (IsValid(context, value))
				return new FilePath((string)value);
			return base.ConvertFrom(context, culture, value);
		}
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
				return destinationType == typeof(string);
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
				return ((FilePath)value).Path;
			return base.ConvertTo(context, culture, value, destinationType);
		}
		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			if (value.GetType() == typeof(string))
				return true;
			return base.IsValid(context, value);
		}
	}
