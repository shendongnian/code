    var a = new HttpWebResponse(...);
    try
    {
       // use a
    }
    finally
    {
        if (a != null)
            a.Dispose();
    }
