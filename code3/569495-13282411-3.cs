    public static class MyCache
    {
         private static object LockToken = new object(); // lock object to manage concurrency
         private static List<CMSUser> _Users { get; set }
         static MyCache()
    	 {
    		_Users = GetUsers();
    	 }
         public static List<CMSUser> Users
         {
              lock (LockToken)
              {
                   return _Users;
              }
         }
    }
