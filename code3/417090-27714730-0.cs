    using System;
    using System.Reflection;
    namespace YourNameSpace
    {
        public class AssemblyInfoHelper
	    {
		    private Assembly _Assembly;
		
            /// <summary>
            /// Whenever we're interested in assembly information, it's 99% of the time the entry assembly
            /// hence used in the default constructor
            /// </summary>
            public AssemblyInfoHelper()
            {
                _Assembly = Assembly.GetEntryAssembly();
            }
            /// <summary>
            /// for cases where we don't want the entry assembly we can supply the desired assembly to interrogate
            /// </summary>
            /// <param name="type"></param>
            public AssemblyInfoHelper(Type type)
            {
                _Assembly = Assembly.GetAssembly(type);
            }
            public AssemblyInfoHelper(string path)
            {
                _Assembly = Assembly.ReflectionOnlyLoadFrom(path);
            }
            private T CustomAttributes<T>()
			    where T : Attribute
		    {
			    object[] customAttributes = _Assembly.GetCustomAttributes(typeof(T), false);
			    if ((customAttributes != null) && (customAttributes.Length > 0))
			    {
				    return ((T)customAttributes[0]);
			    }
			    throw new InvalidOperationException();
		    }
		    public string Title
		    {
			    get
			    {
				    return CustomAttributes<AssemblyTitleAttribute>().Title;
			    }
		    }
		    public string Description
		    {
			    get
			    {
				    return CustomAttributes<AssemblyDescriptionAttribute>().Description;
			    }
		    }
		    public string Company
		    {
			    get
			    {
				    return CustomAttributes<AssemblyCompanyAttribute>().Company;
			    }
		    }
		    public string Product
		    {
			    get
			    {
				    return CustomAttributes<AssemblyProductAttribute>().Product;
			    }
		    }
		    public string Copyright
		    {
			    get
			    {
				    return CustomAttributes<AssemblyCopyrightAttribute>().Copyright;
			    }
		    }
		    public string Trademark
		    {
			    get
			    {
				    return CustomAttributes<AssemblyTrademarkAttribute>().Trademark;
			    }
		    }
		    public string AssemblyVersion
		    {
			    get
			    {
				    return _Assembly.GetName().Version.ToString();
			    }
		    }
		    public string FileVersion
		    {
			    get
			    {
				    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(_Assembly.Location);
				    return fvi.FileVersion;
			    }
		    }
		    public string Guid
		    {
			    get
			    {
				    return CustomAttributes<System.Runtime.InteropServices.GuidAttribute>().Value;
			    }
		    }
        }
    }
