    class AssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            //Load by a type in the assembly
            var _serviceAssembly = Assembly.GetAssembly(typeof(CarsController));
            //Load from a file
            //var _serviceAssembly = Assembly.LoadFrom("abc.dll");
            //Check if the assembly is already in the list
            //if you are getting the assembly reference by a type in it,
            //The assembly will probably be in the list
            if (!assemblies.Contains(_serviceAssembly))
                assemblies.Add(_serviceAssembly);
            return assemblies;
        }
