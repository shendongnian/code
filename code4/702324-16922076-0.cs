    public static string GetFullyQualifiedEnumName<T>(this T @this) where T : struct, IConvertible
	{
	    if (!typeof(T).IsEnum) 
	    {
		    throw new ArgumentException("T must be an enum");
		}
	    var type = typeof(T);
	    return string.Format("{0}.{1}.{2}", type.Namespace, type.Name, Enum.GetName(type, @this));		
	}
