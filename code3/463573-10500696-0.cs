    var bla = "ou";
	var list = new List<string>{
				"Mouse",
				"Dinner",
				"House",
				"Out",
				"Phone",
				"Hat",
				"Ounce"};
				
				
	var groupa = list.GroupBy(x =>x.ToLower().Contains(bla));
	
	groupa.First().ToList().OrderByDescending(x => x.ToLower().StartsWith(bla));
