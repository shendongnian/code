    public class Customer
    {
    	private readonly IReferenceNumberGetter ReferenceNumberGetter;
    
    	public Customer(IReferenceNumberGetter referenceNumberGetter)
    	{
    		ReferenceNumberGetter = referenceNumberGetter;
    	}
    
    	public string GenerateReferenceNumber()
    	{
    		return ReferenceNumberGetter.GenerateReferenceNumber();
    	}
        // other Customer stuff
    }
    
    public interface IReferenceNumberGetter
    {
    	string GenerateReferenceNumber();
    }
    
    public class ReferenceNumberGetterOne : IReferenceNumberGetter
    {
    	public string GenerateReferenceNumber()
    	{
    		return "4";
    	}
    }
    
    public class ReferenceNumberGetterTwo : IReferenceNumberGetter
    {
    	public string GenerateReferenceNumber()
    	{
    		return "42";
    	}
    }
