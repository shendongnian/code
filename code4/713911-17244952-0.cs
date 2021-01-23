		WebRequest request = default(WebRequest);
		request = WebRequest.Create(your_url);
		request.Method = "POST";
		request.ContentType = "application/x-www-form-encoded";
		StreamWriter sw = new StreamWriter(request.GetRequestStream);
		//'// Read the Response
		WebResponse wr = request.GetResponse;
		StreamReader sr = new StreamReader(wr.GetResponseStream);
		var ReturnValue = sr.ReadToEnd.Trim;
	
