	var vehicle = XDocument.Parse(xml)
						   .Descendants("Vehicle")
						   .First();
	Vehicle v = Deserialize<Vehicle>(vehicle.ToString());
	
	//display contents of v	
	Console.WriteLine(v.BodyStyle);   //prints Hatchback
	Console.WriteLine(v.Colour);      //prints Blue
	Console.WriteLine(v.NumOfDoors);  //prints 3
