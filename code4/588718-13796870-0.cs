    SolverContext sc = SolverContext.GetContext();
    Model m = sc.CreateModel();
    
    m.AddDecision(new Decision(Domain.IntegerRange(0,10), "a"));
    m.AddDecision(new Decision(Domain.IntegerRange(0, 10), "b"));
    
    m.AddConstraint(null, "a > 0");
    m.AddConstraint(null, "b == Plus[a,2]");
