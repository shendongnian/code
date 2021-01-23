    public class Singleton { }
    
    public class TestClass1 : IAssemblyFixture<Singleton>
    {
      readonly Singletone _Singletone;
      public TestClass1(Singleton singleton)
      {
        _Singleton = singleton;
      }
    
      [Fact]
      public void Test1()
      {
         //use singleton  
      }
    }
    
    public class TestClass2 : IAssemblyFixture<Singleton>
    {
      readonly Singletone _Singletone;
      public TestClass2(Singleton singleton)
      {
        //same singleton instance of TestClass1
        _Singleton = singleton;
      }
    
      [Fact]
      public void Test2()
      {
         //use singleton  
      }
    }
