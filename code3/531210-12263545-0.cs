    List<string> AllTheTestCases = new List<string>();
    AllTheTestCases.Add("TC001 Passed");
    AllTheTestCases.Add("TC002 Passed");
    AllTheTestCases.Add("TC003 Passed");
    AllTheTestCases.Add("TC003 Passed");
    AllTheTestCases.Add("TC003 Failed");
    AllTheTestCases.Add("TC004 Passed");
    
    List<string> FailedTestCases = AllTheTestCases.Where<string>(x => x.Contains("Failed")).ToList();
    List<string> PassedTestCases = AllTheTestCases.Where<string>(x => x.Contains("Passed")).ToList();
    
    Console.WriteLine("Failed: " + FailedTestCases.Count);
    Console.WriteLine("Passed: " + PassedTestCases.Count);
