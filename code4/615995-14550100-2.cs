    namespace MyProject.Converters
    {
    	public class MetadataParameters
    	{
    		public Type ModelType { get; set; }
    		public string ModelProperty { get; set; }
    		public Type AttributeType { get; set; }
    		public string AttributeProperty { get; set; }
    	}
    
    	public class MetadataConverter : IValueConverter
    	{
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			var mp = parameter as MetadataParameters;
    			var modelPropertyInfo = mp.ModelType.GetProperty(mp.ModelProperty);
    			var attribute = modelPropertyInfo
    				.GetCustomAttributes(true)
    				.Cast<Attribute>()
    				.FirstOrDefault(memberInfo => memberInfo.GetType() == mp.AttributeType);
    			var attributeProperty = attribute.GetType().GetProperty(mp.AttributeProperty);
    
    			return attributeProperty.GetValue(attribute, null);
    		}
    
    		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			throw new NotImplementedException();
    		}
    	}
    }
