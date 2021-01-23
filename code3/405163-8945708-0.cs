         public static void Main()
        {  
           Assembly ass = Assembly.LoadFile(@"PathToLibrar\ClassLibraryTest.dll");
           var type = ass.GetType("ClassLibrary1.Calculator");
           dynamic instance = Activator.CreateInstance(type);
           int add = instance.Calc(1, 3);
         }
