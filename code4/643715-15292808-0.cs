    public string DoWork(Stream objtest)
    {
         StreamReader sr = new StreamReader(stream);
         string s = sr.ReadToEnd();
         sr.Dispose();
         NameValueCollection collection = System.Web.HttpUtility.ParseQueryString(s);
         return collection.ToString();
    }
