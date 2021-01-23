    public class PropertyValue
    {
        int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Value { get; set; }
        
        public string PVType { get; set; } //Could be an enum
        
        public string DisplayFormat { get; set;
    	
    	private string _RawValue;
    
    	public string Value{
    	    get{
    	      switch(PVType){
    			case "DateTime":
    					return Convert.ToDateTime(_RawValue).ToString(DisplayFormat);
    			break;
    			case "Double":
    					return Convert.ToDouble(_RawValue).ToString(DisplayFormat);
    			break;
    			default:
    					return _RawValue;
    	      }
    	    }
    	    set{
    			_RawValue = value;
    	    }
    	}
    
    }
