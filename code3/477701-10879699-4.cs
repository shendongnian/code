    public class Customer
    {
    	public void ChangeEmail(string email)
    	{
    		var rules = Validator.GetRulesFor<Customer>("ChangeEmail");
    		rules.Validate(email);
    		
    		// valid
    	}
    	
    }
