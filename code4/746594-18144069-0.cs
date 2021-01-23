    var coordinates = new List<Coordinate>()
	{
		new Coordinate { X = 164 , Y = 79 , Z = 120 },
		new Coordinate { X = 146 , Y = 63 , Z = 120 },
		new Coordinate { X = 192 , Y = 59 , Z = 120 },
		new Coordinate { X = 196 , Y = 59 , Z = 120 },
		new Coordinate { X = 110 , Y = 55 , Z = 120 },
		new Coordinate { X = 148 , Y = 69 , Z = 122 },
		new Coordinate { X = 194 , Y = 59 , Z = 122 },
		new Coordinate { X =  18 , Y = 47 , Z = 122 }
	};
	var grouped = coordinates
		.Select(c => c.Z)
		.Distinct()
		.ToDictionary(
			z => z, 
			z => coordinates.Where(c => c.Z == z));
