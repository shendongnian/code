    void Main()
    {
    	List<string> AllTheTestCasesStrings = new List<string>();
    	AllTheTestCasesStrings.Add("TC001 Passed");
    	AllTheTestCasesStrings.Add("TC002 Passed");
    	AllTheTestCasesStrings.Add("TC003 Passed");
    	AllTheTestCasesStrings.Add("TC003 Passed");
    	AllTheTestCasesStrings.Add("TC003 Failed");
    	AllTheTestCasesStrings.Add("TC004 Passed");
    	
    	List<TestCase> AllTheTestCases = new List<TestCase>();
    	
    	foreach(string CurrentTest in AllTheTestCasesStrings)
    	{
    		TestCase NewTest = new TestCase();
    		NewTest.Name = CurrentTest.Split(' ')[0];
    		NewTest.Passed = CurrentTest.Split(' ')[1].Equals("Passed");
    		
    		AllTheTestCases.Add(NewTest);
    	}
    	
    	int FailedTestCases = AllTheTestCases.Where<TestCase>(x => !x.Passed).GroupBy<TestCase, string>(x => x.Name).Count();
    	int PassedTestCases = AllTheTestCases.Where<TestCase>(x => x.Passed).GroupBy<TestCase, string>(x => x.Name).Count();
    	
    	Console.WriteLine("Failed: " + FailedTestCases);
    	Console.WriteLine("Passed: " + PassedTestCases);
    }
    
    public class TestCase
    {
    	public string Name;
    	public bool Passed;
    }
