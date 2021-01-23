	var foos = new Item() { Name = "Foo" };
	var bars = new Item() { Name = "Bar" };
	var qazs = new Item() { Name = "Qaz" };
	var wees = new Item() { Name = "Wee" };
	
	foos.Add(bars);
	bars.Add(qazs);
	foos.Add(wees);
	
	Console.WriteLine(foos.LocateItem("Wee"));
	Console.WriteLine(foos.LocateItem("Qaz"));
	Console.WriteLine(foos.LocateItem("Bar"));
	Console.WriteLine(foos.LocateItem("Foo"));
