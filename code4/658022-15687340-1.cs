    string path = "http://localhost:8983/solr/sessions/update?commit=true";
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(path);
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    var data = new[]
    {
        new
        {
            Session_SessionId = "da7007e9-fe7a-4bdf-b9e4-1a55034cf08f",
            Session_HasComments = new {set = true}
        }
    };
    string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data);
    byte[] byteData = new System.Text.ASCIIEncoding().GetBytes(json);
    httpWebRequest.ContentLength = byteData.Length;
    using (Stream stream = httpWebRequest.GetRequestStream())
    {
       stream.Write(byteData,0,byteData.Length);
    }
    HttpWebResponse resp = (HttpWebResponse)httpWebRequest.GetResponse();
    string respStr = new StreamReader(resp.GetResponseStream()).ReadToEnd();
    Console.WriteLine("Response : " + respStr);
