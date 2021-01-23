    public string foo { get; set; }
    public string bar { get; set; }
    
    [MinLength(20, ErrorMessage = "too short")]
    public string foobar 
    { 
    	get
    	{
    		return foo + bar;
    	}
    }
