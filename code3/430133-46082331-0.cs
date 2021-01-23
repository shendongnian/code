    // GET JSON Response
    public WeatherResponseModel GET(string url) {
    	WeatherResponseModel model = new WeatherResponseModel();
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    	try {
    		WebResponse response = request.GetResponse();
    		using(Stream responseStream = response.GetResponseStream()) {
    			StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
    			model = JsonConvert.DeserializeObject < WeatherResponseModel > (reader.ReadToEnd());
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
    
    	return model;
    }
