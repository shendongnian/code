    void Main()
    {
    	Expression<Func<ComplexObj, object>> expression = 
          obj => obj.Contacts[0].SetFirstName("Tim");		
    }
    
    public class ComplexObj
    {
    	public ComplexObj() { Contacts = new List<SimpleObj>(); }
    	public List<SimpleObj> Contacts {get; private set;}
    }
    public class SimpleObj
    {
    	public string FirstName {get; private set;}
    	public SimpleObj SetFirstName(string name) { this.FirstName = name; return this; }
    }
