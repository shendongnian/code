       [AssemblyInitialize]
       public static void InitializeTestAssembly(TestContext ctx)
       {
           if (Application.Current == null)
               new Application();
       }
