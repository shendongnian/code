	Assembly Assemblies_AssemblyResolve(object sender, ResolveEventArgs args)
	{
		if (args.RequestingAssembly != null)
		{
			return LoadAssemblyFromPath(new AssemblyName(args.Name), args.RequestingAssembly.Location);
		}
		if (assemblyTryPath != null)
		{
			return LoadAssemblyFromPath(new AssemblyName(args.Name), assemblyTryPath);
		}
		return null;
	}
