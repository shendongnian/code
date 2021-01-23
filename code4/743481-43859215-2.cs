	// Create a new shallow copy.
	arrPersonClone = (Person[]) arrPerson.Clone();
	
	// Change the name of the first person in the shallow copy.
	arrPersonClone[0].Name = "Peter";
	
	// Display the contents of all arrays.
	Console.WriteLine( "After changing the Name property of the first element in the Shallow Copy" );
	Console.WriteLine( $"The Original Array: {arrPerson[0].Name}, {arrPerson[1].Name}" );
	Console.WriteLine( $"The Shallow Copy: {arrPersonClone[0].Name}, {arrPersonClone[1].Name}" );
