    class Color
    {
      private static new int ToString()
      { return 42; }
      public static new string GetHashCode()
      { return "I'm public!"; }
    }
    static class Program
    {
      static void Main()
      {
        Color Color = new Color();
        var testA = Color.ToString();
        var testB = Color.GetHashCode();
        Console.WriteLine(testA);
        Console.WriteLine(testB);
      }
    }
