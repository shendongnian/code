    class Program
    {
       private static int generatedname(int i)
       {
            return i + i;
       }
       static void Main()
       {
           Func<int, int> sumFunc = generatedname;
       } 
    }
