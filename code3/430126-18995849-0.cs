        var TakingRequset = WebRequest.Create("http://xxx.acv.com/MethodName/Get");
        TakingRequset.Method = "POST";
        TakingRequset.ContentType = "text/xml;charset=utf-8";
        TakingRequset.PreAuthenticate = true;
        //---Serving Request path query
         var PAQ = TakingRequset.RequestUri.PathAndQuery;
        //---creating your xml as per the host reqirement
        string xmlroot=@"<root><childnodes>passing parameters</childnodes></root>";
        string xmlroot2=@"<root><childnodes>passing parameters</childnodes></root>";
        //---Adding Headers as requested by host 
        xmlroot2 = (xmlroot2 + "XXX---");
        //---Adding Headers Value as requested by host 
      //  var RequestheaderVales = Method(xmlroot2);
        WebProxy proxy = new WebProxy("XXXXX-----llll", 8080);
        proxy.Credentials = new NetworkCredential("XXX---uuuu", "XXX----", "XXXX----");
        System.Net.WebRequest.DefaultWebProxy = proxy;
        // Adding The Request into Headers
        TakingRequset.Headers.Add("xxx", "Any Request Variable ");
        TakingRequset.Headers.Add("xxx", "Any Request Variable");
        byte[] byteData = Encoding.UTF8.GetBytes(xmlroot);
        TakingRequset.ContentLength = byteData.Length;
        using (Stream postStream = TakingRequset.GetRequestStream())
        {
            postStream.Write(byteData, 0, byteData.Length);
            postStream.Close();
        }
        StreamReader stredr = new StreamReader(TakingRequset.GetResponse().GetResponseStream());
        string response = stredr.ReadToEnd();
