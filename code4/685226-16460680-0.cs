    class SqlInstanceManager:SqlInstance
        {
            private SqlInstanceManager(){ }
            public static new GetInstance()
            {
                return SqlInstance.GetInstance("key");
            }
        }
    class SqlInstance
            {
                protected SqlInstance()
                {
    
                }
                public void Connect(string username, string password)
                {
                    //connect
                }
                public void Disconnect()
                {
                    //disconnect
                }
                //Make this protected. Now this class cannot be instantiated
                //and it cannot be called without inheriting this class
                //which is sufficient restriction.
                protected static SqlInstance GetInstance(string key)
                {
                    return new SqlInstance();
                }
            }
    
           //And the same thing for FileInstance
    
    
    
         class DataManager
            {
                SqlInstance GetSqlChannelInstance()
                {
                    //if some logic
                    return SqlInstanceManager.GetInstance("dev.1");
    
                    //if some other logic
                    return SqlInstanceManager.GetInstance("dev.2");
    
                    //...and so on
                }
    
               
            }
