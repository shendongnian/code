    class C1 { 
    public: 
      void Test() { }
    }
    
    class C2 { } 
    
    UseIt<C1>(C1());  // Ok
    UseIt<C2>(C2());  // Error! 
