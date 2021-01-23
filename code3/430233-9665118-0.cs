        public class CacheUsers  
        {          
        	 static object objlock;          
        	private static List<Users> usersList { get; set; }          
                   
    
    	public CacheUsers()          
    	{              
    		if (objlock == null)              
    		{                  
    			objlock = new object();              
    		}              
    		lock (objlock)              
    		{                  
    			if (usersList == null || usersList.Count.Equals(0))                  
    			{                      
    				UpdateUserList();                  
    			}              
    		}          
    	} 
               
    	public static List<Users> ListaCacheada          
    	{              
    		get              
    		{                  
    			if (usersList == null || usersList.Count.Equals(0))                  
    			{                      
    				UpdateUserList();                  
    			}                  
    			return usersList;              
    		}          
    	}            
            
    	private static void UpdateUserList()          
    	{              
    		usersList = GetUsers();              	 
    	}    
    }  
    
       
