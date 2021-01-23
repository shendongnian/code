	void GetStatusCode(string url)
	{
		dynamic httpRequest = Activator.CreateInstance(Type.GetTypeFromProgID("MSXML2.XMLHTTP.3.0"));
		httpRequest.Open("GET", url, false);
		try
		{ httpRequest.Send(); }
		catch {}
		finally
		{ Console.WriteLine(httpRequest.Status);}
	}
