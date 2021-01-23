    public void LoadModule()
    {
         var asm = System.Reflection.Assembly.Load(/* Get the developer module name from somewhere*/);
         var types = asm.GetExportedTypes();
         foreach(var t in types)
         {
             foreach(var i = t.GetInterfaces())
             {
                 if(i == typeof(IModule))
                 {
                     var iModule = System.Activator.CreateInstance(t);
                     iModule.Run();
                 }
             }
         }
    }
