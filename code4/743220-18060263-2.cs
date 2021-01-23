    using System;
    using System.Collections.Generic;
    
    static class Program
    {
      static void Main()
      {
        int i = 19; // to be captured by lambda, will become field on a generated class
        Func<int> f = () => i;
        var target = f.Target;  // when debugging type looks like "Program."
        Console.WriteLine(target.GetType().ToString()); // writes "Program+<>c__DisplayClass1"
    
        var seq = GetSeq();  // when debugging type looks like "Program.GetSeq"
        Console.WriteLine(seq.GetType().ToString()); // writes "Program+<GetSeq>d__3"
      }
    
      static IEnumerable<int> GetSeq() // returns "state machine" (iterator block)
      {
        yield return 42;
      }
    }
