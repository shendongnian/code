    [DataContract]
    public class Store
    {
    	[DataMember]
    	 public string TpoStoreid {get; set;}
    
    	[DataMember]
    	public Region {get; set;}
    	  
    	 //more properties..
    }
    
    [DataContract]
    public class Region
    {
    	[DataMember]
    	public string TpoRegionId {get; set;}
    	
    	[DataMember]
    	public Account {get; set;}
    	
    	//more properties..
    }
    
    [DataContract]
    public class Account {
    	//.....
    }
