    Assembly dynamicAssembly = //generated
    var derivedInstances = dynamicAssembly.GetTypes()
        .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BaseClass)))
        .Select(t => (BaseClass)Activator.CreateInstance(t));
        
    foreach(BaseClass bc in derivedInstances)
    {
        //run tests
    }
