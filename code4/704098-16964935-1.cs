    class Program
    {
      private const int internalIterations = 1000;
      private const int externalIterations = 100;
      private const int dataSize = 100000;
      private const int search = dataSize - 1;
 
      private static readonly long[] resultsFirst = new long[externalIterations*2];
      private static readonly long[] resultsWhereFirst = new long[externalIterations*2];
      private static readonly int[] data = Enumerable.Range(0, dataSize).ToArray();
      static void Main(string[] args)
      {
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < externalIterations; i++)
        {
          Console.WriteLine("Iteration {0} of {1}", i+1, externalIterations);
          sw.Restart();
          First();
          sw.Stop();
          resultsFirst[i*2] = sw.ElapsedTicks;
          Console.WriteLine("     First : {0}", sw.ElapsedTicks);
          sw.Restart();
          WhereFirst();
          sw.Stop();
          resultsWhereFirst[i*2] = sw.ElapsedTicks;
          Console.WriteLine("WhereFirst : {0}", sw.ElapsedTicks);
          sw.Restart();
          WhereFirst();
          sw.Stop();
          resultsWhereFirst[(i*2)+1] = sw.ElapsedTicks;
          Console.WriteLine("WhereFirst : {0}", sw.ElapsedTicks);
          sw.Restart();
          First();
          sw.Stop();
          resultsFirst[(i*2)+1] = sw.ElapsedTicks;
          Console.WriteLine("     First : {0}", sw.ElapsedTicks);
        }
        Console.WriteLine("Done!");
        Console.WriteLine("Averages:");
        Console.WriteLine("     First Average: {0:0.00}", resultsFirst.Average());
        Console.WriteLine("WhereFirst Average: {0:0.00}", resultsWhereFirst.Average());
      }
      private static void WhereFirst()
      {
        for (int i = 0; i < internalIterations; i++)
        {
          int item = data.Where(d => d == search).First();
        }
      }
      private static void First()
      {
        for (int i = 0; i < internalIterations; i++)
        {
          int item = data.First(d => d == search);
        }
      }
    }
