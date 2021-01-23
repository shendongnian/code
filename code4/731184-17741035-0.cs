    public void LoadAssembly()
    {
         AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
         var a = Assembly.Load("foo");
         Type myType = a.GetType("Example");
        
        // Get the method to call.
        MethodInfo myMethod = myType.GetMethod("MethodA");
        
        // Create an instance. 
        object obj = Activator.CreateInstance(myType);
        
        // Execute the method.
        myMethod.Invoke(obj, null);
    }
        
    private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
         if (IntPtr.Size == 4)
         {
              // return your 32-bit.
         }
         else if (IntPtr.Size == 8)
         {
              // return your 64-bit.
         }
    }
