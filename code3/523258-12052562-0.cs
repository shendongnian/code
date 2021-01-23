    class A
    {    
      private instance;    
      public virtual void Method1 ()
      {
        AMethod1();       
      }
    
      protected void AMethod1()
      {
        instance = this;
        do something;       
      }
    }
