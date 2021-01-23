    HttpWebRequest myHttpWebRequest = null;
	HttpWebResponse myHttpWebResponse = null;
	try
	{
		String weatherURL = "http://smart-ip.net/geoip-xml/" + txtIP.Text;
		myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(weatherURL);
		myHttpWebRequest.Method = "GET";
		myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
		myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
		//---- <Added code> -------
		var doc = XDocument.Load(myHttpWebResponse.GetResponseStream());
		var geoip = doc.Element("geoip");
		var country = geoip.Element("countryName").Value;
		var city = geoip.Element("city").Value;
		Console.WriteLine(country + " - " + city);
		//---- </Added code> -------
	}
	catch (Exception myException)
	{
		throw new Exception("Error Occurred:", myException);
	}
	finally
	{
		myHttpWebRequest = null;
		myHttpWebResponse = null;
	}
