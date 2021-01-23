    class Facade {
      private A a;
      private B b;
      // Provides an interface to A and B by delegating to these members  
      public void DoSomethingWithAAndB() {
        MagicToken x = a.DoSomethingAndGetAResult();
        b.DoSomethingWithMagic(x);
      } 
    }
