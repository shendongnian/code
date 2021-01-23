    internal static class Deserializer
    {
        internal static Dictionary<string, string> Deserialize (System.Web.HttpRequestBase Request)
        {
            Request.InputStream.Position = 0;
            string Json = new StreamReader(Request.InputStream).ReadToEnd();
            return new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(Json);
        }
    }
