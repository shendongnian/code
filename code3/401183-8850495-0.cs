	private IEnumerable<Assembly> GetDependentAssemblies(Assembly analyzedAssembly)
	{
		return AppDomain.CurrentDomain.GetAssemblies()
			.Where(a => GetNamesOfAssembliesReferencedBy(a)
                                .Contains(analyzedAssembly.FullName));
	}
	public IEnumerable<string> GetNamesOfAssembliesReferencedBy(Assembly assembly)
	{
		return assembly.GetReferencedAssemblies()
			.Select(assemblyName => assemblyName.FullName);
	}
