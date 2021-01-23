        using System;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
    	// Create web client simulating IE6.
    	using (WebClient client = new WebClient())
    	{	   
    
    	client.DownloadStringCompleted += HttpsCompleted;
        client.DownloadStringAsync(new Uri("https://domain/path/file.xml"));
    	}
        }
    }
