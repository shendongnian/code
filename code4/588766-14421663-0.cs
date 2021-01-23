    if URLExists(theURL){
    Response.Redirect(theUrl);
    }
    else{
    //redirect somewhere else
    }
    
    
    public static bool UrlExists(string url)
            {
                try
                {
                    if (url == "")
                    {
                        return false;
                    }
                    else
                    {
                        new System.Net.WebClient().DownloadData(url);
                        return true;
                    }
                }
                catch (System.Net.WebException e)
                {
                    try
                    {
                        if (((System.Net.HttpWebResponse)e.Response).StatusCode == System.Net.HttpStatusCode.NotFound)
                            return false;
                        else
                            throw;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
