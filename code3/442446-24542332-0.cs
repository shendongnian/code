     public string HTTPGet(string URL, string Proxy, string certName = null, string certPassword = null)
     {
        Easy easy = new Easy();
		SockBuff = "";
		try
		{
			Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
			easy.SetOpt(CURLoption.CURLOPT_URL, URL);
			easy.SetOpt(CURLoption.CURLOPT_TIMEOUT, "60");
			easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
			easy.SetOpt(CURLoption.CURLOPT_USERAGENT, UserAgent);
			easy.SetOpt(CURLoption.CURLOPT_COOKIEFILE, CookieFile);
			easy.SetOpt(CURLoption.CURLOPT_COOKIEJAR, CookieFile);
			easy.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, true);
			if (!string.IsNullOrEmpty(certName))
			{
				easy.SetOpt(CURLoption.CURLOPT_SSLCERT, certName);
				if (!string.IsNullOrEmpty(certPassword))
				{
					easy.SetOpt(CURLoption.CURLOPT_SSLCERTPASSWD, certPassword);
				}
			}
			if (URL.Contains("https"))
			{
				easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, 1);
				easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, 0);
			}
			if (!string.IsNullOrEmpty(Proxy))
			{
				easy.SetOpt(CURLoption.CURLOPT_PROXY, Proxy);
				easy.SetOpt(CURLoption.CURLOPT_PROXYTYPE, CURLproxyType.CURLPROXY_HTTP);
			}
			
			var code = easy.Perform();
			easy.Cleanup();
			Console.WriteLine(code);
		}
		catch
		{
			Console.WriteLine("Get Request Error");
		}
		return SockBuff;
	}
    public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
	{
		// Console.Write(System.Text.Encoding.UTF8.GetString(buf));
		SockBuff = SockBuff + System.Text.Encoding.UTF8.GetString(buf);
		return size * nmemb;
	}
