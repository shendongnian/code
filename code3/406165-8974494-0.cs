    public static string GetLocalizedName(Enum enumeration){
    	System.Reflection.MemberInfo[] mi = enumeration.GetType().GetMember(enumeration.ToString());
    	LocalDescription ld =  (LocalDescription) Attribute.GetCustomAttribute(mi[0], typeof(LocalDescription), false);
    	if (null != ld)
    	return getfromresource(ld.CultureCode, ld.ResourceKey);
    }
