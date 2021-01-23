    response = null;
	try
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("<url>");
		response = (HttpWebResponse)request.GetResponse();
		//no error
	}
	catch (WebException e)
	{
		if (e.Status == WebExceptionStatus.ProtocolError)
		{
 			response = (HttpWebResponse)e.Response;
			if((int)response.StatusCode == 500)
			{
				using (StreamReader sr = new StreamReader(response.GetResponseStream()))
				{
					var result = sr.ReadToEnd();
				}
			}
		}
	}
