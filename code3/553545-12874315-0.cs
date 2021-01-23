    try
    {
          Parallel.Foreach(...)//50 Thread For Each Time
          {
               string str = MyMethod();
          }
    }
    catch (MyCookieException ex)
    {
        CookieContainer c = ex.CookieContainer;
    }
    public string MyMethod()
    {
         CookieContainer cookieJar = new CookieContainer();
         try
         {
             // Some Codes That Make An Exception
         }
         catch (Exception ex)
         {
             throw new MyCookieException(ex, cookieJar);
         }
    }
