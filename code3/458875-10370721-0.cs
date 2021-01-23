    void Main()
    {
    	int selectedIndex = 1;
    	Country test;
    	test = (Country)selectedIndex;
    	Console.WriteLine(test.ToString());
    	Console.WriteLine(((Country)selectedIndex).ToString());
    }
    
    enum Country
    {
    	None,
    	Australia,
    	Austria,
    	England,
    	France,
    	Germany,
    	UnitedStates
    }
