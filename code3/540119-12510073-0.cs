    public class A : IClassB
    {
       public IClassB B { get; }
       private class B : IClassB
       {
           public int B1 { get; }
       }
    }
    public interface IClassB
    {
       int B1 { get; }
    }
