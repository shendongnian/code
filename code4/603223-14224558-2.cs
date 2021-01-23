       [AssemblyInitialize]
       public static void InitializeTestAssembly(TestContext ctx)
       {
           if (Application.Curent == null)
               new Application();
       }
