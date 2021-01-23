        string one = "1234-TTT";
		
		string pattern = "TTT";
		Regex reg = new Regex(pattern);
		string two = "&reg";
		string result = reg.Replace(one, two);
        Console.WriteLine(result);
