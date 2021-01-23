	var lst = new List<string>();
	var dic = new Dictionary<int, int>();
	string s = "Hello!";
	object obj1 = new { Id = 10 };
	object obj2 = null;
	
    // True
	Console.Write(lst.GetType().IsGenericType && lst is IEnumerable);
    // True
	Console.Write(dic.GetType().IsGenericType && dic is IEnumerable);
    // False
	Console.Write(s.GetType().IsGenericType && s is IEnumerable);
    // False
	Console.Write(obj1.GetType().IsGenericType && obj1 is IEnumerable);
    // NullReferenceException: Object reference not set to an instance of 
    // an object, so you need to check for null cases too
	Console.Write(obj2.GetType().IsGenericType && obj2 is IEnumerable);
