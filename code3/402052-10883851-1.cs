    internal static Func<ITypeInfo,Guid> GetTypeInfoGuid = (Func<ITypeInfo,Guid>)Delegate.CreateDelegate(typeof(Func<ITypeInfo,Guid>), typeof(Marshal).GetMethod("GetTypeInfoGuid", BindingFlags.NonPublic | BindingFlags.Static, null, new[]{typeof(ITypeInfo)}, null), true);
    public static Type GetCOMObjectType(object comobject)
    {
    	if(!Marshal.IsComObject(comobject))
    	{
    		throw new ArgumentException("This is not COM object.", "comobject");
    	}
    	IDispatch dispatch = (IDispatch)comobject;
    	ITypeInfo info;
    	dispatch.GetTypeInfo(0,0, out info);
    	string name;
    	string docString;
    	int dwHelpContext;
    	string strHelpFile;
    	info.GetDocumentation(-1, out name, out docString, out dwHelpContext, out strHelpFile);
    	Guid guid = GetTypeInfoGuid(info);
    	foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    	{
    		foreach(Type t in a.GetTypes())
    		{
    			if(t.IsInterface && t.IsImport && t.GUID == guid)
    			{
    				return t;
    			}
    		}
    	}
    	return Type.GetTypeFromCLSID(guid);
    }
