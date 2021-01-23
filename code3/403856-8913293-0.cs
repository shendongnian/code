    public interface IEventRepository
    {
      void Method1();
      void Method2();
    }
    
    public abstract class BaseEvents : IEventRepository
    {
      public void Method1() 
      {
        Console.WriteLine("This is shared functionality");
      }
    
      public abstract void Method2();
    }
    
    public class Implementation1 : BaseEvents
    {
      override public void Method2()
      {
        Console.WriteLine("Impl1.Method2");
      }
    }
    
    public class Implementation2 : BaseEvents
    {
      override public void Method2()
      {
        Console.WriteLine("Impl2.Method2");
      }
    }
    public class Program
    {
      static void Main(string[] args)
      {
        var implementations = new List<IEventRepository> { new Implementation1(), new Implementation2() };
    
        foreach (var i in implementations) 
        {
           Console.WriteLine(i.GetType().Name);
           Console.Write("\t");
           i.Method1();  // writes 'This is shared functionality'
           
           Console.Write("\t");
           i.Method2(); // writes type specific message
        }
      }
}
