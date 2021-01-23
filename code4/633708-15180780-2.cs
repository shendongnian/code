    using System;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Resources;
	using System.Windows.Data;
	namespace AppResourceLib.Public.Reflection
	{
	  [ValueConversion(typeof(Object), typeof(String))]
	  public class LocalizedDescriptionConverter : IValueConverter
	  {
		public Object Convert(Object value, Type targetType, Object param, CultureInfo cultureInfo)
		{
		  String description = null;
		  if (null != value)
		  {
			// If everything fails then at least return the value.ToString().
			description = value.ToString();
			// Get the LocalizedDescriptionAttribute of the object.
			LocalizedDescriptionAttribute attribute =
			  value.GetType().GetCustomAttribute(typeof(LocalizedDescriptionAttribute))
			  as LocalizedDescriptionAttribute;
			// Make sure we found a LocalizedDescriptionAttribute.
			if (null != attribute)
			{          
			  ResourceManager resourceManager = 
				ResourceManagerCache.GetResourceManager(attribute.ResourceType);
			  if (null != resourceManager)
			  {
				// Use the ResourceManager to get the description you gave the object value.
				// Here we just use the object value.ToString() (the name of the object) to get
				// the string in the .resx file. The only constraint here is that you have to
				// name your object description strings in the .resx file the same as your objects.
				// The benefit is that you only have to declare the LocalizedDescriptionAttribute
				// above the object type, not an attribute over every object.
				// And this way is localizable.
				description = resourceManager.GetString(value.ToString(), cultureInfo);
				String formatString = (param as String);
				// If a format string was passed in as a parameter,
				// make a string out of that.
				if (!String.IsNullOrEmpty(formatString))
				{
				  formatString = formatString.Replace("\\t", "\t");
				  formatString = formatString.Replace("\\n", "\n");
				  formatString = formatString.Replace("\\r", "\r");
				  description = String.Format(formatString, value.ToString(), description);              
				}          
			  }
			}
		  }
		  return description;      
		}
		public Object ConvertBack(Object value, Type targetType, Object param, CultureInfo cultureInfo)
		{
		  throw new NotImplementedException();
		  return null;
            }
	  }
	}
