		// note that it must be List<IPair<object>> not List<Pair<object>>
		// because only IPair is covariant, not directly Pair
		var pairs= new List<IPair<object>>{
			new Pair<string>{First = "first", Second = "second"},
			new Pair<Uri>{
				First = new Uri("http://www.google.com"), 
				Second = new Uri("http://www.facebook.com")},			
			new Pair<object>{First = 1, Second = 2}
		}; 
		foreach(var p in pairs) {
        	Console.WriteLine(p.ToString());
			Console.WriteLine("swapping...");
			Console.WriteLine(Application.Swap(p).ToString());
			Console.WriteLine();			
		}
