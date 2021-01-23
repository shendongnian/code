    private static int generatedname(int i)
    {
      return i + i;
    }
    class Program
    {
       static void Main()
       {
           Func<int, int> sumFunc = generatedname;
       } 
    }
