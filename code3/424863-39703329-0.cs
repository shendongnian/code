    public string CallWebService(string URL)
    {
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(URL);
        objRequest.Method = "GET";
        objRequest.KeepAlive = false;
    
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        string result = "";
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
    	    result = sr.ReadToEnd();
    	    sr.Close();
        }
        return result;
    }
