	var TListGen = typeof(List<>);
	var TListInt = typeof(List<int>); // this would be "concrete" in the sense
									  // that its generic arguments
									  // are all parametrized
	var TTest = typeof(List<>).MakeGenericType(typeof(List<>).MakeGenericType(typeof(List<>)));									  	
	
	
	(!TListGen.ContainsGenericParameters).Dump(); // False
	(!TListInt.ContainsGenericParameters).Dump(); // True
	(!TTest.ContainsGenericParameters).Dump(); // False
