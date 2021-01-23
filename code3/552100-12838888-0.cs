    public static void Main (string[] args) 
    { 
        int k = 0; 
        int i = 3; 
        var loopRes = Parallel.For (0, 20, (J, loopState) => 
        { 
            try { k = i / J; }
            catch { loopState.Break(); }
            Console.WriteLine ("Result After division " + J + " = " + k); 
        } 
        ); 
     
        if (loopRes.IsCompleted) { 
            Console.WriteLine ("Loop was successful"); 
        } 
        if (loopRes.LowestBreakIteration.HasValue) { 
            Console.WriteLine ("loopRes.LowestBreakIteration.Value = " + loopRes.LowestBreakIteration.Value); 
        } 
    }  
