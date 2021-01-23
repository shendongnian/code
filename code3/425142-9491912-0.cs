		//string[] searchIn = File.ReadAllLines("File1.txt");
		//string[] searchFor = File.ReadAllLines("File2.txt");
		string[] searchIn = new string[] {"A","AB","ABC","ABCD", null, "", "    "};
		string[] searchFor = new string[] {"A","BC","BCD", null, "", "   "};
		matchDictionary;
		
		foreach(string item in file2Content)
		{
			string[] matchingItems = Array.FindAll(searchIn, x => (x == item) || (!string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(item) ? (x.Contains(item) || item.Contains(x)) : false));
		}
