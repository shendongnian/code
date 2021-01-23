    // POST a JSON string
    void POST(string url, string jsonContent) {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    	request.Method = "POST";
    
    	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
    	Byte[]byteArray = encoding.GetBytes(jsonContent);
    
    	request.ContentLength = byteArray.Length;
    	request.ContentType =  @ "application/json";
    
    	using(Stream dataStream = request.GetRequestStream()) {
    		dataStream.Write(byteArray, 0, byteArray.Length);
    	}
    	long length = 0;
    	try {
    		using(HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
    			// got response
    			length = response.ContentLength;
    		}
    	} catch (WebException ex) {
    		WebResponse errorResponse = ex.Response;
    		using(Stream responseStream = errorResponse.GetResponseStream()) {
    			StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
    			String errorText = reader.ReadToEnd();
    			// log errorText
    		}
    		throw;
    	}
    }
