    public class ValidatableCustomOrder : CustomOrder
    {
    	public bool IsValid { get; private set; }
    
    	public ValidatableCustomOrder()
    	{
    	
    	}
    	
    	public ValidatableCustomOrder(ValidatableCustomOrder copiedOrder)
    		: base(copiedOrder)
    	{
    		this.IsValid = copiedOrder.IsValid;
    	}
    }
