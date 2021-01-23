       [TestClass()]
       public class DivideClassTest
       {
          [AssemblyInitialize()]
          public static void AssemblyInit(TestContext context)
          {
             Console.WriteLine("Assembly Init");
             }
    
          [ClassInitialize()]
          public static void ClassInit(TestContext context)
          {
             Console.WriteLine("ClassInit");
          }
    
          [TestInitialize()]
          public void Initialize()
          {
             Console.WriteLine("TestMethodInit");
          }
    
          [TestCleanup()]
          public void Cleanup()
          {
             Console.WriteLine("TestMethodCleanup");
          }
    
          [ClassCleanup()]
          public static void ClassCleanup()
          {
             Console.WriteLine("ClassCleanup");
          }
    
          [AssemblyCleanup()]
          public static void AssemblyCleanup()
          {
             Console.WriteLine("AssemblyCleanup");
          }
    
          [TestMethod()]
          public void Test1()
          {
    		  Console.WriteLine("Test1");
    	  }
          [TestMethod()]
          public void Test2()
          {
    		  Console.WriteLine("Test2");
          }
      } 
   
