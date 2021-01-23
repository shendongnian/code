    // mock data
	var data = new List<dynamic> {
	    new { Age = 0, Count = 6 },
		new { Age = 1, Count = 6 },
		new { Age = 2, Count = 7 },
		new { Age = 3, Count = 5 },
		new { Age = 4, Count = 5 },
		new { Age = 5, Count = 20 },
		new { Age = 6, Count = 5 },
		new { Age = 7, Count = 5 },
		new { Age = 8, Count = 5 },
		new { Age = 9, Count = 5 },
		new { Age = 10, Count = 5 },
	};
	
	var age = new { 
	                ZeroToFive = data.Where(x => x.Age < 6).Sum(x => x.Count),
			        AboveSix = data.Where(x => x.Age >= 6).Sum(x => x.Count)
	              };
