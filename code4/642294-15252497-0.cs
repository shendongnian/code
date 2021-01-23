    public partial class Person
    {
    	public string Name { get; set; }
    	public string FirstName { get; set; }
    	...
    }
    
    ...
    
    public partial class Person
    {
    	public DateTime CurrentDateTime { get; set; }
    }
    
    ...
    
    var listOfPersons = MyContext.Persons.Cast<Person>();
    foreach (var person in listOfPersons)
    {
    	person.CurrentDateTime = ....
    }
