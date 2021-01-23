    public class Person
    {
    	public Person(string forename, string surname, string dateOfBirth)
    	{
    		Forename = forename;
    		Surname = surname;
    		DateOfBirth = dateOfBirth;
    	}
    	public string Forename { get; set; }
    	public string Surname { get; set; }
    	public string DateOfBirth { get; set; }
    
    	public override string ToString()
    	{
    		return Forename + ";" + Surname + ";" + DateOfBirth;
    	}
    }
