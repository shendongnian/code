    	public string GetTargetFramework()
		{
			System.Reflection.Assembly assembly;
			Attribute[] attributes;
			System.Runtime.Versioning.TargetFrameworkAttribute targetFrameworkAttribute;
			assembly = Assembly.GetEntryAssembly();
			attributes = AssemblyDescriptionAttribute.GetCustomAttributes(assembly);
			foreach(Attribute item in attributes)
			{
				targetFrameworkAttribute = item as System.Runtime.Versioning.TargetFrameworkAttribute;
				if(targetFrameworkAttribute != null)
					return targetFrameworkAttribute.FrameworkDisplayName;
			}
			return null; // "TargetFrameworkAttribute not found"
		}
