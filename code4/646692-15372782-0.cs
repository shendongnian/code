    bool fileExists = false;
    try
     {
    	  HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create("http://sub1.mysite.com/img/10.jpg");
    	  using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    	  {
    		   fileExists = (response.StatusCode == HttpStatusCode.OK);
    	  }
     }
     catch
     {
     }
