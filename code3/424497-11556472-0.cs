    HttpWebResponse response = null;
    try
    {
        //...
        response = (HttpWebResponse)request.GetResponse();
        //...
    }
    catch(Exception e)
    {
        // logging, etc.
        throw e;
    }
    finally
    {
        if(response!=null)
        {
            response.Close();
        }
    }
