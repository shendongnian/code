    //Add a Static Constructor which is guaranteed to be called exactly once
    // “before the first instance is created or any static members are referenced.”, 
    // so therefore before the dependent assemblies are loaded.
     static ScriptMain()
     {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
     }
     //Provide path to dll stored in folder on file system
     static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
     {
    
         string path = @"D:\DLL\";
         return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "Newtonsoft.dll"));
    
      }
