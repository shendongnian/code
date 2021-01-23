	// Create a reference copy.
	var arrPersonR = arrPerson;
	
	// Change the name of the first person.
	arrPersonR[0].Name = "NameChanged";
	// Replace the second person.
	arrPersonR[1] = new Person(){ Name = "PersonChanged" };
	
	// Display the contents of all arrays.
	Console.WriteLine( "After changing the reference copy:" );
	Console.WriteLine( $"The Original Array: {arrPerson[0].Name}, {arrPerson[1].Name}" );
	Console.WriteLine( $"The Reference Copy: {arrPersonR[0].Name}, {arrPersonR[1].Name}" );
