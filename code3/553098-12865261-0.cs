    using System.Net;
    
    using (WebClient client = new WebClient ()) 
    {
        html = client.DownloadString(@"http://somesite.com/somepage.html");        
    }
