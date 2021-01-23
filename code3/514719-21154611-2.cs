    try {
     WebClient client = new WebClient();
     client.Encoding = Encoding.UTF8;
     string content = client.DownloadString("https://sandiegodata.atlassian.net/wiki/pages/doaddcomment.action?pageId=524365");
     Console.WriteLine(content);
     Console.ReadKey();
    } catch (WebException ex) {
     var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
     Console.WriteLine(resp);
     Console.ReadKey();
    }
            
