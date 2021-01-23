    public static TestAbstractFactory
    {
      public static TestAbstract(int whichClass)
      { 
          switch(whichClass)
          {
          case 0:
            return new ClassA();
          case 1:
            return new ClassB();
          case 10:
            return new ClassX();
          }
      }
    }
