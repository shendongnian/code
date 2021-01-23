    catch(WebException ex)
    {
        Console.WriteLine(ex.Message);
        if (ex.Status == WebExceptionStatus.ProtocolError)
        {
            Console.WriteLine("Status Code : {0}", ((HttpWebResponse)ex.Response).StatusCode);
            Console.WriteLine("Status Description : {0}", ((HttpWebResponse)ex.Response).StatusDescription);
            using (Stream responseStream = ex.Response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                        Console.WriteLine(responseReader.ReadToEnd());
                    }
                }
            }
        }
    }
