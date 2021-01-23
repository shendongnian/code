    [Serializable]
    public class Data
    {
    	public string Field1 {get; set;}
    }
    
    [Serializable]
    public class Data2
    {
    	public Data2() { _version1 = new Data();}
    	
    	[NonSerialized]
    	private Data _version1;	
    	public string Field1 
    	{ 
    		get { return _version1.Field1;} 
    		set { _version1.Field1 = value;}
    	}
    	public int Field2 {get; set;}
    }
    
    [Serializable]
    public class Data3
    {
    	public Data3() { _version2 = new Data2();}
    
    	[NonSerialized]
    	private Data2 _version2;
    	public string Field1 
    	{ 
    		get { return _version2.Field1;} 
    		set { _version2.Field1 = value;}
    	}
    	public int Field2 
    	{ 
    		get { return _version2.Field2;} 
    		set { _version2.Field2 = value;}
    	}
    	public double Field3 {get; set;}	
    }
