		Assembly Assemblies_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			if (args.RequestingAssembly != null)
			{
				return LoadAssemblyFromPath(new AssemblyName(args.Name), args.RequestingAssembly.Location);
			}
			else
			{
				if (assemblyTryPath != null)
				{
					return LoadAssemblyFromPath(new AssemblyName(args.Name), assemblyTryPath);
				}
				else
				{
					return null;
				}
			}
		}
