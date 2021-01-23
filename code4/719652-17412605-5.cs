    public class LocalizedEnumAttribute : DescriptionAttribute
    {
    	private PropertyInfo _nameProperty;
    	private Type _resourceType;
    
    	public LocalizedEnumAttribute(string displayNameKey)
    		: base(displayNameKey)
    	{
    	}
    
    	public Type NameResourceType
    	{
    		get
    		{
    			return _resourceType;
    		}
    		set
    		{
    			_resourceType = value;
    
    			_nameProperty = _resourceType.GetProperty(this.Description, BindingFlags.Static | BindingFlags.Public);
    		}
    	}
    
    	public override string Description
    	{
    		get
    		{
    			//check if nameProperty is null and return original display name value
    			if (_nameProperty == null)
    			{
    				return base.Description;
    			}
    
    			return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
    		}
    	}
    }
    
