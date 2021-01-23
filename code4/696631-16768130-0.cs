    public  interface IA
    {
      string SomeMethod();
    }
    public interface IB
    {
      string SomeMethod();
    }
    class MyConcreteClass:IA, IB
    {
      string IA.SomeMethod()
      {
         return "For IA";       
      }
      string IB.SomeMethod()
      {
         return "For IB";       
      }
    }
    IA concA = new MyConcreteClass();
    IB concB = new MyConcreteClass();
     Console.WriteLine(concA.SomeMethod()); // print "For IA"
     Console.WriteLine(concB.SomeMethod()); // print "For IB"
