	public class CookiesAwareWebClient : WebClient
	{
		private CookieContainer outboundCookies = new CookieContainer();
		private CookieCollection inboundCookies = new CookieCollection();
		public CookieContainer OutboundCookies
		{
			get
			{
				return outboundCookies;
			}
		}
		public CookieCollection InboundCookies
		{
			get
			{ 
				return inboundCookies; 
			}
		}
		public bool IgnoreRedirects { get; set; }
		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest request = base.GetWebRequest(address);
			if (request is HttpWebRequest)
			{
				(request as HttpWebRequest).CookieContainer = outboundCookies;
				(request as HttpWebRequest).AllowAutoRedirect = !IgnoreRedirects;
			}
			return request;
		}
		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse response = base.GetWebResponse(request);
			if (response is HttpWebResponse)
			{
				inboundCookies = (response as HttpWebResponse).Cookies ?? inboundCookies;
			}
			return response;
		}
	}
