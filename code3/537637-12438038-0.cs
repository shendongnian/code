    static void Main()
    {
        var personList = new List<Person>{
    	    new Person("David Johnson"),
    		new Person("William Black"),
    		new Person("David Smith"),
    		new Person("Matthew Edwards"),
    		new Person("Jayden Anderson"),
    		new Person("Andrew Connor"),
    		new Person("Adam Johnson"),
    		new Person("Daniel Armstrong"),
    		new Person("Steve Anderson"),
    		new Person("Daniel Black")	
    	};
    
        var sortedPersonList = personList.OrderBy(p => p.Forename).ThenBy(p => p.Surname);
    
    	foreach (var person in sortedPersonList)
    	{
    		Console.WriteLine(person);
    	}
    	
    	Console.Read();
    }
    
    public class Person
    {
    	public Person(string name)
    	{
    		var names = name.Split(' ');
    		Forename = names[0];
    		Surname = names[1];
    	}
    
    	public string Forename { get; set; }
    	public string Surname { get; set; }
	public override string ToString()
	{
		return Forename + " " + Surname;
	}
    }
