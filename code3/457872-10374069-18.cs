    public class Person
    {
    	public virtual int PersonId { get; set;	}
    	public virtual string Lastname { get; set; }
    	public virtual string Firstname { get; set; }
    	
    	public virtual IList<PhoneNumber> PhoneNumbers { get; set; }
    	
    	
    	public virtual void AddPhoneNumbers(PhoneNumber pn)
    	{
    		pn.Person = this;
    		PhoneNumbers.Add(pn);
    	}
    }
