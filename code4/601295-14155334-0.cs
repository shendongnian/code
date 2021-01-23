    public static string getSourceCode(string url)
    {
           try
           { 
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "text/html; charset=ISO-8859-15";
            //ERROR in here 404 or timeout
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream()); 
            string sourceCode = sr.ReadToEnd();
            sr.Close();
            resp.Close();
            return sourceCode;
          }
          catch(Exception ex){}
    }
