    List<string> TestList= new List<string>();
	TestList.Add("Apple"); // Add string 1
	TestList.Add("Banana"); // 2
	TestList.Add("Mango"); // 3
	TestList.Add("Blue Berry"); // 4
	TestList.Add("Water Melon"); // 5
	string JoinDataString = string.Join(",", TestList.ToArray());
	
