    void Main()
    {
    	var f = new Foo
    	{
    		GetQuestions = new Dictionary<string, string>
    				{
    					{"s1", "Q1,Q2"},
    					{"s2", "Q1,Q2,Q3"},
    					{"s3", "Q1,Q2,Q4"},
    					{"s4", "Q1,Q2,Q4,Q6"},
    				}
    	};
    	
    	JsonConvert.SerializeObject(f).Dump();
    }
    
    class Foo
    {
    	public Dictionary<string, string> GetQuestions { get; set; }
    }
