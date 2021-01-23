    try
    {
        var wResp = (HttpWebResponse)wReq.GetResponse();
        var wRespStatusCode = wResp.StatusCode;
    }
    catch (WebException we)
    {
        var wRespStatusCode = ((HttpWebResponse)we.Response).StatusCode;
        if( wRespStatusCode == HttpStatusCode. Unauthorized)
        {
           // call to your sign in / login logic here
        } else{
            throw we;
        }
    }
