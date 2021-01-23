	Action<IEnumerable<int>> DumpList = l => Console.WriteLine("\t[{0}]", String.Join(", ", l));
	Action<string> DumpRange = s => Console.WriteLine("\t\"{0}\"", s);
	
	var numbers = new[] { 1, 1, 2, 3, 4, 5, 12, 13, 19, 19 };
	DumpList(numbers);
	var str = ConvertNumberListToRangeString(numbers);
	DumpRange(str);
	var list = ConvertRangeStringToNumberList(str);
	DumpList(list);
	
	Console.WriteLine();	
	
	str = "1-5, 12, 13, 19, 20, 21, 2-7";
	DumpRange(str);
	list = ConvertRangeStringToNumberList(str);
	DumpList(list);
	str = ConvertNumberListToRangeString(list);
	DumpRange(str);
