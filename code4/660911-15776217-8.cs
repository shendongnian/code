	var list = new List<int> {1,2,3,4,5,6};
	
	Console.WriteLine ("cutted items:");
	Console.WriteLine (string.Join(Environment.NewLine, list.CutOff(2)));
	
	Console.WriteLine ("items in list:");
	Console.WriteLine (string.Join(Environment.NewLine, list));
