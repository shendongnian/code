    using System;
    using System.Net;
    using System.Threading;
    using System.IO;
    using System.Text;
    class ThreadTest
    {
        static void Main()
        {
            WebRequest req = WebRequest.Create("http://www.yourDomain.com/search");
    
            req.Proxy = null;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
    
            string reqString = "searchtextbox=webclient&searchmode=simple"; 
            byte[] reqData = Encoding.UTF8.GetBytes(reqString); 
            req.ContentLength = reqData.Length;
    
            using (Stream reqStream = req.GetRequestStream())
                reqStream.Write(reqData, 0, reqData.Length);
    
            using (WebResponse res = req.GetResponse())
            using (Stream resSteam = res.GetResponseStream())
            using (StreamReader sr = new StreamReader(resSteam)) 
                File.WriteAllText("SearchResults.html", sr.ReadToEnd());
    
            System.Diagnostics.Process.Start("SearchResults.html");
    
        }
    
    }
