    public List<object> LoadObjectsFromAssembly(Assembly assemblyContainingClasses)
    {
         var objectList = new List<object>();
         List<Type> classNames = assemblyContainingClasses.GetTypes().Where(t => t.IsClass && !t.IsAbstract).ToList();
         var assemblyPathTemplate = assemblyContainingClasses.GetName().Name + ".{0}";
         foreach(var className in classNames) 
         {
             Type typeToLoad = assemblyContainingClasses.GetType(string.Format(assemblyPathTemplate, className));
             objectList.Add(Activator.CreateInstance(typeToLoad));
         }
         return objectList;
    }
