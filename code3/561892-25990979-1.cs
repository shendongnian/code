    static void main(string[] args)
    {
        Initialize();
        RealMain();
    }
    
    static voit Initialize()
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
    }
    
    static void RealMain()
    {
       // <-- here the app tries to resolve MyAssembly
       // class contained in an assemnly that we need to resolve      
       MyAssembly.Class1 myClass = new MyAssembly.Class1();
       // and everything is OK
    }
