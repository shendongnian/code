    namespace TestDLLTest
    {
      class TestDLLTest
      {
        static void Main(string[] args)
        {
          AppDomain domain = AppDomain.CreateDomain( "DLLTest" );
          domain.ExecuteAssembly( "DllTest.dll" );
          DLLTest dt = new DLLTest();
          int res2 = dt.Add(6, 8);
          int a = 1;
        }
      }
    }
