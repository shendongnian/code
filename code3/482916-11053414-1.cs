    public static Stream DownloadImageData(CookieContainer cookies, string siteURL)
    {
		HttpWebRequest httpRequest = null;
		HttpWebResponse httpResponse = null;
		httpRequest = (HttpWebRequest)WebRequest.Create(siteURL);
		httpRequest.CookieContainer = cookies;
		httpRequest.AllowAutoRedirect = true;
		try
		{
			httpResponse = (HttpWebResponse)httpRequest.GetResponse();
			if (httpResponse.StatusCode == HttpStatusCode.OK)
			{
				var httpContentData = httpResponse.GetResponseStream();
				return httpContentData;
			}
			return null;
		}
		catch (WebException we)
		{
			return null;
		}
		finally
		{
			if (httpResponse != null)
			{
				httpResponse.Close();
			}
		}
	}
