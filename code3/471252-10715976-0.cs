    try {
    			System.Net.HttpWebRequest oHTTPRequest = System.Net.HttpWebRequest.Create("URL of Request") as System.Net.HttpWebRequest;
    			System.Net.HttpWebResponse oHTTPResponse = oHTTPRequest.GetResponse as System.Net.HttpWebResponse;
    			System.IO.StreamReader sr = new System.IO.StreamReader(oHTTPResponse.GetResponseStream);
    			string respString = System.Web.HttpUtility.HtmlDecode(sr.ReadToEnd());
    		} 
    		catch (Exception oEX) 
    		{
    			//Log an Error
    		}
    	}
