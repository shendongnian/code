    public interface IMyInterface
    {
      int P1 {set; get;}
      int P2 {set; get;}
    }
    public class A : IMyInterface
    {
      public int P1 {set; get;}
      public int P2 {set; get;} 
    }
    public class B : IMyInterface
    {
      public B(IMyInterface i)
      {
        P1 = i.P1;
        P2 = i.P2;
      }
      public int P1 {set; get;}
      public int P2 {set; get;}
 
      public int P3 {set; get;}
      public int P4 {set; get;} 
    }
