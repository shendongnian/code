    double[] minimums = Parameters.Select(p => p.Value.Item1).ToArray();
    double[] maximums = Parameters.Select(p => p.Value.Item2).ToArray();
    // Some initial values, here it's a quick and dirty average
    double[] initials = Parameters.Select(p => (p.Item1 + p.Item2)/2.0).ToArray();
    var solution = NelderMeadSolver.Solve(
        x => myRanker.LinearTrial(x, false), initials, minimums, maximums);
    // Make sure you check solution.Result to ensure that it found a solution.
    // For this, I'll assume it did.
    // Value 0 is the minimized value of LinearTrial
    int i = 1;
    foreach (var param in Parameters)
    {
        Console.WriteLine("{0}: {1}", param.Key, solution.GetValue(i));
        i++;
    }        
