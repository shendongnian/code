    // ...
    group e by de into t
    select new
    {
        PatientID = t.Key.PatientID,
        CodeID = t.Key.CodeID,
        Occurences = t.Count(d => t.Key.CodeID == d.CodeID),
        // taking original items with us
        Items = t
    };
