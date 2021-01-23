	var peopleList = new List<string>();
	var enterpriseList = new List<string>();
	var homeList = new List<string>();
	List<string> workingList = null;
   
	using (var reader = new StreamReader("input.txt"))
	{
		string line = reader.ReadLine();
		while (line != null)
		{
			switch (line)
			{
				case "PEOPLE": { workingList = peopleList; } break;
				case "ENTERPRISE": { workingList = enterpriseList; } break;
				case "HOME": { workingList = homeList; } break;
				
				default: { workingList.Add(line); } break;
			}
			
			line = reader.ReadLine();
		}
	}
