        public class Service : System.Web.Services.WebService
        {
    	   private Func<DBAccess> getDBAccess;
    	
    	   public Service(Func<DBAccess> getDBAccess)
    	   {
    	      this.getDBAccess = getDBAccess;
    	   }
    
    	   [WebMethod]
    	   public List<Profile> XXX(Guid a, uint b, DateTime c)
    	   {
    	        using(var dbaccess = this.getDBAccess())
                {
                    return dbaccess.XXX(a, b, c);
                }  
    	   }
    	   ...
         }
