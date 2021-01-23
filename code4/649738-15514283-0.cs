    List<List<string>> divStrings(int ExpectedStringsPerArray, List<string> AllStrings)
    {
    	//Set what we're currently up to in the array
    	var espa = ExpectedStringsPerArray;
    	var ListOfLists = new List<List<string>>();
    	
    	//Add the first bunch of elements to the list of lists.
    	ListOfLists.Add(AllStrings.Take(ExpectedStringsPerArray).ToList());
    	
    	//While we still have elements left to get out
    	while (AllStrings.Skip(espa).Take(ExpectedStringsPerArray).Count() != 0)
    	{
    		//Add the list data we're currently up to to the list of lists
    		ListOfLists.Add(AllStrings.Skip(espa).Take(ExpectedStringsPerArray).ToList());
    		//Offset what we're up to so next time we're getting the next lot of data
    		espa += ExpectedStringsPerArray;
    	}
    	
    	return ListOfLists;
    }
