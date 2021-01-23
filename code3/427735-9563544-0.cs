    // Fullest version
    l.Find((ABC a) => { return a.A==4; });
    // Infer the type of the parameter
    l.Find((a) => { return a.A==4; });
    // Single parameter - can remove the ()
    l.Find(a => { return a.A==4; });
    // Single expression - can remove braces and semi-colon
    l.Find(a => a.A == 4);
