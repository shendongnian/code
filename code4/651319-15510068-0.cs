    var model = new Model();
    var session = engine.CreateSession(model);
    var submission = session.CompileSubmission<dynamic>(script);
    foreach (Model data in models)
    {
        model.InputA = data.InputA;
        model.InputB = data.InputB;
        model.Factor = data.Factor;
    
        dynamic result = submission.Execute();
        Console.WriteLine("{0} {1} {2}", result.Σ, result.Δ, result.λ);
    }
