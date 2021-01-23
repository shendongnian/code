    string s = "510";
    int? test = s.TryParse<int>();
    //TryParse Returns 510 and stored in variable test.
    string s = "TestInt";
    int? test = s.TryParse<int>();
    //TryParse Returns null and stored in variable test.
