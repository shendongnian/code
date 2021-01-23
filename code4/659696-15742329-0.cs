    string input = @"mstest.exe  /testcontainer:\TestPayment.dll /resultsfile:""\Resultfile_TestPayment_1.trx"" /runconfig: /detail:owner /detail:duration /detail:description /unique  /test:TestPayment.CreditCardTestCases.BoletoFunctionalTestCase /test:TestPayment.CreditCardTestCases.BoletoEndToEndFunctionalTestCase /test:TestPayment.CreditCardTestCases.BoletoPurcahseTestCase /test:TestPayment.CreditCardTestCases.CreditCard_ResumeOrder_Success /test:TestPayment.CreditCardTestCases.CreditCard_EURCurr_USBilling_ENUS /test:TestPayment.CreditCardTestCases.DinersClubPayment";
    
    const int LINE_LIMIT = 300;
    const string TEST_MARKER = " /test:";
    
    int testIndex = input.IndexOf(TEST_MARKER);
    string prefix = input.Substring(0, testIndex);
    int availableCharacters = LINE_LIMIT - prefix.Length;
    
    Queue<string> tests = new Queue<string>(input.Substring(testIndex).Split(new []{TEST_MARKER}, StringSplitOptions.RemoveEmptyEntries));
    
    List<string> testSets = new List<string>();
    string currentTest = "";
    while (tests.Count > 0)
    {
    	//restores the test marker from splitting
    	string test = TEST_MARKER + tests.Dequeue(); 
    	
    	if (currentTest.Length + test.Length > availableCharacters)
    	{
    		testSets.Add(currentTest);
    		currentTest = "";
    	}
    	else
    	{
    		currentTest += test;
    	}
    }
    
    if (currentTest != "")
    {
    	testSets.Add(currentTest);
    }
    
    var lines = testSets.Select(t => prefix + t).ToList(); //your line outputs
