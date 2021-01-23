    public static class TypeConverterChecker
    {
    	public static bool Check(Type fromType, Type toType, object fromObject)
    	{
    		Type converterType = typeof(TypeConverterChecker<,>).MakeGenericType(fromType, toType);
    		object instance = Activator.CreateInstance(converterType, fromObject);
    		return (bool)converterType.GetProperty("CanConvert").GetGetMethod().Invoke(instance, null);
    	}
    }
