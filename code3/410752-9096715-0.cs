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
      public int P1 {set; get;}
      public int P2 {set; get;}
 
      public int P3 {set; get;}
      public int P4 {set; get;} 
    }
