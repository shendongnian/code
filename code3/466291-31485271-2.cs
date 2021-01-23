	public static bool IsBlittable<T>()
	{
		return IsBlittableCache<T>.Value;
	}
	
	public static bool IsBlittable(Type type)
	{
		if(type.IsArray)
		{
			var elem = type.GetElementType();
			return elem.IsValueType && IsBlittable(elem);
		}
        try{
			object instance = FormatterServices.GetUninitializedObject(type);
			GCHandle.Alloc(instance, GCHandleType.Pinned).Free();
			return true;
        }catch{
			return false;
		}
	}
	
	private static class IsBlittableCache<T>
	{
		public static readonly bool Value = IsBlittable(typeof(T));
	}
