     System.Net.HttpWebRequest rq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(yourUrlString);           
     rq.Method = "Get";
     rq.ContentType = "text/xml";
     System.Net.HttpWebResponse rs = (System.Net.HttpWebResponse)rq.GetResponse();
     if (rs.Server=="Microsoft-IIS/6.0") 
     {
        //IIS 6 Code
     }
     if (rs.Server=="MMicrosoft-IIS/7.5")
     {
        //IIS 7.5 Code
     }
