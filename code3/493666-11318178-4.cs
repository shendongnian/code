    private static void Main(string[] args)
    {
        var solver = SolverContext.GetContext();
        var model = solver.CreateModel();
        var A = new[,]
            {
                { 1, 0, 0, 0, 0 }, 
                { 0.760652602, 1, 0, 0, 0 }, 
                { 0.373419404, 0.760537565, 1, 0, 0 },
                { 0.136996731, 0.373331934, 0.760422587, 1, 0 },
                { 0.040625222, 0.136953801, 0.373244464, 0.76030755, 1 }
            };
        var b = new[] { 2017159, 1609660, 837732.8125, 330977.3125, 87528.38281 };
        var n = A.GetLength(1);
        var x = new Decision[n];
        for (var i = 0; i < n; ++i)
            model.AddDecision(x[i] = new Decision(Domain.RealNonnegative, null));
        // START NLP SECTION
        var m = A.GetLength(0);
        Term goal = 0.0;
        for (var j = 0; j < m; ++j)
        {
            Term Ax = 0.0;
            for (var i = 0; i < n; ++i) Ax += A[j, i] * x[i];
            goal += Model.Power(Ax - b[j], 2.0);
        }
        model.AddGoal(null, GoalKind.Minimize, goal);
        // END NLP SECTION
        var solution = solver.Solve();
        Console.WriteLine("f = {0}", solution.Goals.First().ToDouble());
        for (var i = 0; i < n; ++i) Console.WriteLine("x[{0}] = {1}", i, x[i].GetDouble());
    }
