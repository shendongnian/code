    public static void Main(string[] args)
    {
      IEnumerable<DateTime> times = GetTimes();
      foreach (var step in times.StepWise())
      {
        while (condition)
        { 
          step.MoveNext();
        }
        Console.WriteLine(step.Current);
      }
    }
