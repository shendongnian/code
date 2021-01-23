    try
    {
        Parallel.ForEach(...)
        {
            string str = MyMethod();
        }
    }
    catch (AggregateException ae)
    {
        // This is where you can choose which exceptions to handle.
        foreach (var ex in ae.InnerExceptions.OfType<MyCookieException>())
        {
            CookieContainer c = ex.CookieContainer;
            // Do stuff with CookieContainer.
        }
    }
    public string MyMethod()
    {
         CookieContainer cookieJar = new CookieContainer();
         try
         {
             // Some code that throws an exception
         }
         catch (Exception ex)
         {
             throw new MyCookieException(ex, cookieJar);
         }
    }
