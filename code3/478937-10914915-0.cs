    public string Col1Wrapper
    {
    	get
    	{
    		return this.Col1;
    	}
    	set
    	{
    		ValidateRequired("Col1Wrapper", value, "Required");
    		ValidateRegularExpression("Col1Wrapper", value, @"^[\d]+$", "Must be digit");
    		ValidateTotal(value,Col2,Col3,total);//in your case
    		this.Col1 = value;
    		this.RaisePropertyChanged("Col1Wrapper");
    	}
    }
    
    public string Col2Wrapper
    {
    	get
    	{
    		return this.Col2;
    	}
    	set
    	{
    		ValidateRequired("Col2Wrapper", value, "Required");
    		ValidateRegularExpression("Col2Wrapper", value, @"^[\d]+$", "Must be digit");
    		ValidateTotal(Col1,value,Col3,total);//in your case
    		this.Col2 = value;
    		this.RaisePropertyChanged("Col2Wrapper");
    	}
    }
    
    public string Col3Wrapper
    {
    	get
    	{
    		return this.Col3;
    	}
    	set
    	{
    		ValidateRequired("Col3Wrapper", value, "Required");
    		ValidateRegularExpression("Col3Wrapper", value, @"^[\d]+$", "Must be digit");
    		ValidateTotal(Col1,Col2,value,total);//in your case
    		this.Col3 = value;
    		this.RaisePropertyChanged("Col3Wrapper");
    	}
    }
