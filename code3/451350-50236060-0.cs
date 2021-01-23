	Type t1 = typeof(HashSet<int>);
	bool test1 = t1.IsGenericType && 
		t1.GetGenericTypeDefinition() == typeof(HashSet<>); // true
	Type t2 = typeof(Dictionary<int, string>);
	bool test2 = t2.IsGenericType && 
		t2.GetGenericTypeDefinition() == typeof(HashSet<>); // false
	Type t3 = typeof(int);
	bool test3 = t3.IsGenericType && 
		t3.GetGenericTypeDefinition() == typeof(HashSet<>); // false
