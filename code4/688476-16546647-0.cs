            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = assemblies.SelectMany(x => x.GetTypes());
            var implTypes = allTypes.Where(t => !t.IsInterface && !t.IsAbstract)
                     .Where(t => typeof (IAnimal).IsAssignableFrom(t));
            var animals = implTypes.Select(t => (IAnimal) Activator.CreateInstance(t))
                                   .ToArray();
