    public static bool IsSubclassOfTypeOrInterface(this Type type, Type ofTypeOrInterface)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (ofTypeOrInterface == null)
		{
			throw new ArgumentNullException("ofTypeOrInterface");
		}
		return ofTypeOrInterface.IsInterface
			       ? type.GetInterfaces().Contains(ofTypeOrInterface)
			       : type.IsSubclassOf(ofTypeOrInterface);
    }
