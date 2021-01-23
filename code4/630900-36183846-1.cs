    List<string> testList= new List<string>();
	testList.Add("Apple"); // Add string 1
	testList.Add("Banana"); // 2
	testList.Add("Mango"); // 3
	testList.Add("Blue Berry"); // 4
	testList.Add("Water Melon"); // 5
	string JoinDataString = string.Join(",", testList.ToArray());
	
