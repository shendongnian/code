	// Create a shallow copy.
	var arrPersonClone = (Person[]) arrPerson.Clone();
	
	// Replace an element in the shallow copy.
	arrPersonClone[0] = new Person(){Name = "Peter"};
	
	// Display the contents of all arrays.
	Console.WriteLine( "After replacing the first element in the Shallow Copy" );
	Console.WriteLine( $"The Original Array: {arrPerson[0].Name}, {arrPerson[1].Name}" );
	Console.WriteLine( $"The Shallow Copy: {arrPersonClone[0].Name}, {arrPersonClone[1].Name}" );
