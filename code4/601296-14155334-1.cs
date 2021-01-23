    public static string getSourceCode(string url)
    {
           string sourceCode = string.Empty;
           try
           { 
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "text/html; charset=ISO-8859-15";
            //ERROR in here 404 or timeout
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream()); 
            sourceCode = sr.ReadToEnd();
            sr.Close();
            resp.Close();
            
          }
          catch(Exception ex){}
          return sourceCode;
    }
