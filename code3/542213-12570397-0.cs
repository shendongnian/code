    class A
    {
      public C<A> Pro1 { get; set; }
    }
    class B
    {
      public C<B> Pro2 { get; set; }
    }
    public class C<T> where T : class   // maybe you want to add other "where" constraints on T
    {
      public void Do()
      {
        // you can use T in here
      }
    }
