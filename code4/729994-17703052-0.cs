    public class Family
    {
    	public Family()
    	{
    		this.FamilyMembers = new List<Person>();
    	}
    	public IList<Person> FamilyMembers {get; protected set;}
    	
    	public void AddFamilyMember(Person person)
    	{
    		this.FamilyMembers.Add(person);
    		person.Family = this;
    	}
    }
