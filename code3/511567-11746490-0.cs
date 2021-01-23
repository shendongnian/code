     var objects = new List<Object>();
     Assembly SampleAssembly;
     SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");
     // Obtain a reference to types known to exist in assembly.
     Type[] types = SampleAssembly.GetTypes();
     foreach(Type t in types)
        if(t.Name.StartsWith("P132")
           objects.Add(Activator.CreateInstance(t));
         
