	var kg = new Mass(5.0, Mass.Units.Kilogram);
	
	Console.WriteLine(kg); // writes "5 Kilogram"
	
	var g = kg.ConvertTo(Mass.G);
	
	Console.WriteLine(g); // writes ".005 Gram"
