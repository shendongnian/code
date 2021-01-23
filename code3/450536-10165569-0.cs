    public static string GetHtml2(string urlAddr)
    {
        if (urlAddr == null || string.IsNullOrEmpty(urlAddr))
        {
            throw new ArgumentNullException("urlAddr");
        }
        else
        {
            string result;
            //1.Create the request object
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddr);
            //request.AllowAutoRedirect = true;
            //request.MaximumAutomaticRedirections = 200;
            request.Proxy = null;
            request.UseDefaultCredentials = true;
            //2.Add the container with the active
            CookieContainer cc = new CookieContainer();
            //3.Must assing a cookie container for the request to pull the cookies
            request.CookieContainer = cc;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                //Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }
    }
