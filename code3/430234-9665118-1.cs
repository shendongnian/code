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
               
      	private static void UpdateUserList()          
    	{         
                     usersList = GetList(); 
                    HttpRuntime.Cache.Insert("Key", usersList , null,
                                Cache.NoAbsoluteExpiration,
                                Cache.NoSlidingExpiration,
                                System.Web.Caching.CacheItemPriority.NotRemovable,
                                ReportRemovedCallback
                                );          	 
    	}    
    }  
    
       
