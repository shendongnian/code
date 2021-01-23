    {
        Uri uri = new Uri("http://localhost:8080/game/Css/style.css");
        WebRequest req = WebRequest.Create(uri);
        WebResponse web = req.GetResponse();
        Stream stream = web.GetResponseStream();
        string content = string.Empty;
        using (StreamReader sr = new StreamReader(stream))
        {
            content = sr.ReadToEnd();
        }
        content.Replace("class='replace'", "new value");
        using (StreamWriter sw = new StreamWriter("D://p.htm"))
        {
            sw.Write(content);
            sw.Flush();
        }
    }
