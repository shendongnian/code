    //common base for any implementation of A
    //repeat for B and C
    public class A1Base : Base, A
    { 
      public void M1() { M1Impl(); }
      public void M2() { M2Impl(); }      
    }
    public class A1 : A1Base { }
