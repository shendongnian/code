    try
    {
        using (HttpWebResponse response ...)
        {
           ...
        }
    }
    catch (System.Net.WebException)
    {
        // handle the exception here
    }
