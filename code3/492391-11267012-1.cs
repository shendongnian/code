    public RequiredCollectionAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
    	{
    	  bool isValid = base.IsValid(value);
    	  
    	  if(isValid)
    	  {
    	  	ICollection collection = value as ICollection;
    		if(collection != null)
    		{
    	  		isValid = collection.Count != 0;
    		}
    	  }	 
    	  return isValid;
    	}
    }
    
       
