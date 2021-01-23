    // Not guaranteed to work since I work only with FluentValidation for past year
    public class PostalCodeValidator : ValidationAttribute
    {
    	public override bool IsValid(object value)
    	{
    		var address = (Address)value;
    		
    		if ((address.Country == "Canada" || address.Country == "France") && address.PostalCode == null)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    }
