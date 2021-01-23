    static void main(string[] args)
    {
        // <-- here the app tries to resolve MyAssembly
        // and as MyAssembly.Class1 is not found, the app crashes
        // this next line is never called:
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
    
        // class contained in an assemnly that we need to resolve
        MyAssembly.Class1 myClass = new MyAssembly.Class1();
    }
