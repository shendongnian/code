            public string MyMethod()
            {
                CookieContainer cookieJar = new CookieContainer();
                try
                {
    
                    // Some Codes That Make An Exception
                    string str = MyMethod();
                }
                catch (Exception)
                {
                     if (cookieJar != null)
                    {
                        // do whatever u want
                    }
                }
                finally
                {
                    if (cookieJar != null)
                    {
                        // do whatever u want
                    }
                }
            }  
    
        
