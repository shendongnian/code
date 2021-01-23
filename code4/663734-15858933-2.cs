	List<string> list = new List<string>();
	list.Add("polo");
	Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>() ;
	dict.Add(1, list);
	Console.WriteLine(dump(list));
	Console.WriteLine(dump(dict.First()));
	Console.WriteLine(dump(dict));
