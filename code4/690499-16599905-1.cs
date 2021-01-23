    public List<object> LoadObjectsFromAssembly(Assembly assemblyContainingClasses)
    {
         var objectList = new List<object>();
         List<Type> classNames = assemblyContainingClasses.GetTypes().Where(t => t.IsClass && !t.IsAbstract).ToList();
         foreach(var classType in classNames) 
         {
             Type typeToLoad = assemblyContainingClasses.GetType(classType.FullName);
             objectList.Add(Activator.CreateInstance(typeToLoad));
         }
         return objectList;
    }
