    internal class AssemblyResolver : MarshalByRefObject
    {
      static internal void Register(AppDomain domain)
      {
        AssemblyResolver resolver =
            domain.CreateInstanceFromAndUnwrap(
              Assembly.GetExecutingAssembly().Location,
              typeof(AssemblyResolver).FullName) as AssemblyResolver;
        resolver.RegisterDomain(domain);
      }
      private void RegisterDomain(AppDomain domain)
      {
        domain.AssemblyResolve += ResolveAssembly;
        domain.AssemblyLoad += LoadAssembly;
      }
      private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
      {
        // implement assembly resolving here
        return null;
      }
      private void LoadAssembly(object sender, AssemblyLoadEventArgs args)
      {
        // implement assembly loading here
      }
    }
