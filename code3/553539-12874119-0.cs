    public class PersonOrganizationEntry
    {
    	public Person Person { get; private set; }
    	public Organization Organization { get; private set; }
    	
    	public PersonOrganizationType Type { get; private set; }
    	
    	public PersonOrganizationEntry(Person person)
    	{
    		this.Person = person;
    		this.Type = PersonOrganizationType.Person;
    	}
    	
    	public PersonOrganizationEntry(Organization organization)
    	{
    		this.Organization = organization;
    		this.Type = PersonOrganizationType.Organization;
    	}
    }
    
    public enum PersonOrganizationType
    {
    	Person,
    	Organization
    }
