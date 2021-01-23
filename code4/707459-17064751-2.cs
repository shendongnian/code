    class Program
    {
      static void Main(string[] args)
      {
        Stuff
          stuff1 = new Stuff(),
          stuff2 = new Stuff { };
    
        Console.WriteLine(stuff1.SomeInfo == null);
        Console.WriteLine(stuff2.SomeInfo == null);
    
        Console.WriteLine("Press <Enter>.");
        Console.ReadLine();
      }
    }
    
    public class Stuff
    {
      private String _SomeInfo;
      public String SomeInfo
      {
        get { return _SomeInfo; }
        set
        {
          _SomeInfo = value ?? String.Empty;
        }
      }
    }
