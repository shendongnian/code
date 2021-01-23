		Uri url = new Uri("http://app/templat");
		HttpWebRequest request = null;
		
		ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
		CookieContainer cookieJar = new CookieContainer();
		request = (HttpWebRequest)WebRequest.Create(url);
		request.CookieContainer = cookieJar;
		request.Method = "GET";
		HttpStatusCode responseStatus;
		
		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		{
			responseStatus = response.StatusCode;
			url = request.Address;
		}
		
		if (responseStatus == HttpStatusCode.OK)
		{
			UriBuilder urlBuilder = new UriBuilder(url);
			urlBuilder.Path = urlBuilder.Path.Remove(urlBuilder.Path.LastIndexOf('/')) + "/j_security_check";
			
			request = (HttpWebRequest)WebRequest.Create(urlBuilder.ToString());
			request.Referer = url.ToString();
			request.CookieContainer = cookieJar;
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			
			using (Stream requestStream = request.GetRequestStream())
			using (StreamWriter requestWriter = new StreamWriter(requestStream, Encoding.ASCII))
			{
				string postData = "j_username=user&j_password=user&submit=Send";
				requestWriter.Write(postData);
			}
						
			string responseContent = null;
			
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader responseReader = new StreamReader(responseStream))
			{
				responseContent = responseReader.ReadToEnd();
			}
			
			Console.WriteLine(responseContent);
		}
		else
		{
			Console.WriteLine("Client was unable to connect!");
		}		
