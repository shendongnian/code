    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
    myRequest.Method = "GET";
    using(WebResponse myResponse = myRequest.GetResponse() )
    {
        using(StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8)) 
        {
            string result = sr.ReadToEnd();
        }
    }
