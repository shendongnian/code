    public class MyStringLengthAttribute : StringLengthAttribute
    {
    	private string _value;	
    
    	public override string FormatErrorMessage(string name)
    	{	
    		return string.Format("Value {0} is not valid.", value);
    	}
    
    	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    	{
    		_value = value.ToString();
    		return base.IsValid(value, validationContext);
    	}
    }
