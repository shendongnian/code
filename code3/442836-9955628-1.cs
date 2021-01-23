    /* ForEach loop as above */
    if (!loopResult.IsCompleted && 
             !loopResult.LowestBreakIteration.HasValue)
    {
       Debug.WriteLine("Loop was stopped");
    }
    
    if (loopResult.IsCompleted)
    {
        Debug.WriteLine("Loop was done without stopping");
    }
