    MultiKeyDictionary<string> dict = new MultiKeyDictionary<string>();
	dict.Add("Hello" , 1,2,3,"StringKey"); // First item is value, remaining all are keys
	Console.WriteLine(dict[1]); // Note 1 is key and not intex
	Console.WriteLine(dict[2]); // Note 2 is key and not index
	Console.WriteLine(dict["StringKey"]);
