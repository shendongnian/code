    public static class PropertyInfoEx
    {
    		public static T GetCustomAttribute<T>(this PropertyInfo propertyInfo, bool inherit) where T : Attribute
    		{
    			object[] attributes = propertyInfo.GetCustomAttributes(typeof(T), inherit);
    
    			return attributes == null || attributes.Length == 0 ? null : attributes[0] as T;
    		}
    
    }
