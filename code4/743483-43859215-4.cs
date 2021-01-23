    void Main()
    {
    	// Create 2 Persons.
    	var person1 = new Person(){ Name = "Jack" };
    	var person2 = new Person(){ Name = "Amy" };
    	
    	// Create a Person array.
    	var arrPerson = new Person[] { person1, person2 };
    
    	// ----------- 1. A shallow copy copies elements. -----------
    	
    	// Create a shallow copy.
    	var arrPersonClone = (Person[]) arrPerson.Clone();
    	
    	// Replace an element in the shallow copy.
    	arrPersonClone[0] = new Person(){Name = "Peter"};
    	
    	// Display the contents of all arrays.
    	Console.WriteLine( "After replacing the first element in the Shallow Copy:" );
    	Console.WriteLine( $"The Original Array: {arrPerson[0].Name}, {arrPerson[1].Name}" );
    	Console.WriteLine( $"The Shallow Copy: {arrPersonClone[0].Name}, {arrPersonClone[1].Name}" );
    	
    	Console.WriteLine( "\n" );
    	
    	// ----------- 2. A shallow copy retains the original references of the elements. -----------
    	
    	// Create a new shallow copy.
    	arrPersonClone = (Person[]) arrPerson.Clone();
    	
    	// Change the name of the first person in the shallow copy.
    	arrPersonClone[0].Name = "Peter";
    	
    	// Display the contents of all arrays.
    	Console.WriteLine( "After changing the Name property of the first element in the Shallow Copy:" );
    	Console.WriteLine( $"The Original Array: {arrPerson[0].Name}, {arrPerson[1].Name}" );
    	Console.WriteLine( $"The Shallow Copy: {arrPersonClone[0].Name}, {arrPersonClone[1].Name}" );
    		
    	Console.WriteLine( "\n" );	
    		
    	// ----------- 2. The equal sign. -----------
    	
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
    }
    
    class Person
    {
    	public string Name {get; set;}
    }
