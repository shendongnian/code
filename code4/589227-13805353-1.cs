    public static classs SomeClass
    {
    
    private static object locker;
    
    private static void closeConnection()
        {
            if(connection != null)
            {
                lock(locker)
                {
                    if(connection != null) //might have been set to null by another thread so need to check again
                    {
                        try
                        {
                            connection.Close(); // <-- this should work now
                        }
                        catch(Exception)
                        { //Don't swallow an exception here
                        }
    
                        connection = null;
                    }
                }
           }
    }
