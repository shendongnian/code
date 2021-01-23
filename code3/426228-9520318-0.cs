    public class A
    {
      public int B;
      public void C()
      {
        return this.B;
      }
    }
    public class D : A
    {
      public int X;
      public new void C()
      {
        var X = 1.0m;
        return X;
      }
    }
  
