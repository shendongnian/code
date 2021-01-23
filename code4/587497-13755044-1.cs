	List<ClassA> list1 = new List<ClassA>();
	List<ClassB> list2 = new List<ClassB>();
	
	list1.Add(new ClassA { Id = 2, name = "a2" });
	list1.Add(new ClassA { Id = 3, name = "a3" });
	list1.Add(new ClassA { Id = 4, name = "a4" });
	list1.Add(new ClassA { Id = 5, name = "a5" });
	
	list2.Add(new ClassB { Id = 1, name = "b1" });
	list2.Add(new ClassB { Id = 2, name = "b2" });
	list2.Add(new ClassB { Id = 4, name = "b4" });
	list2.Add(new ClassB { Id = 5, name = "b5" });
	
	// Goal is to set ClassA::myObjectB from List1 to 
	// matching instance (if any) of ClassB from List2
	var query = 
		from a in list1
		from b in list2
		where a.Id == b.Id
		select Tuple.Create(a, b);	
	foreach (var element in query)
		element.Item1.myObjectB = element.Item2;
