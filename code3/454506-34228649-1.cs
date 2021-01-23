    public static class TypeExtensions
    {
    	public static IEnumerable<FieldInfo> GetConstants(this Type type)
    	{
    		var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
    
    		return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly);
    	}
    
    	public static IEnumerable<string> GetConstantsValues(this Type type)
    	{
    		var fieldInfos = GetConstants(type);
    
    		return fieldInfos.Select(fi => fi.GetRawConstantValue() as string);
    	}
    }
