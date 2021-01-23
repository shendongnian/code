    public class OutputOfPhase<TOutput>
    {
    }
    
    public class Phase<TInput, TOutput> : OutputOfPhase<TOutput>
    {
          private OutputOfPhase<TInput> prerequisite;
    
          public Phase(OutputOfPhase<TInput> prereq, Func<TInput, TOutput> work)
          {
          /* ... */
          }
    }
