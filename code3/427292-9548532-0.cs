    public class Person
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    
    	public bool SameAge(Person otherPerson)
    	{
    		return Age == otherPerson.Age;
    	}
    
    	public bool SameName(Person otherPerson)
    	{
    		return Name == otherPerson.Name;
    	}
    }
