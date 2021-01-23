    Assembly dll = Assembly.LoadFrom(DLLPATH);
    if (dll != null)
    {
       Type Tp = dll.GetType("ABCD.FooClass");
       if (Tp != null)
       {
          Object obj = Activator.CreateInstance(Tp);
          if (obj != null)
          {                            
             MethodInfo[] AllMethods = obj.GetType().GetMethods();
             MethodInfo Found = AllMethods.FirstOrDefault(mi => mi.Name == "Foo" && mi.GetParameters().Count() == 0);
             if (Found != null)
                 List = (List<String>)Found.Invoke(obj, null);           
          }
          else
            Console.WriteLine("obj is null");       
       }
        else
         Console.WriteLine("Type is null");
     }
      else
         Console.WriteLine("Dll is not loaded");
