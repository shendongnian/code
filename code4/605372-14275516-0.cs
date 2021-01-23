	public class DisablePostCachingModule : IHttpModule
	{
        private HttpApplication _context;
		public void Init(HttpApplication context)
		{
            _context = context;
            _context.PreSendRequestHeaders += OnPreSendRequestHeaders;
		}
		public void Dispose()
		{
		}
		private void OnPreSendRequestHeaders(object sender, EventArgs e)
		{
			if (HttpContext.Current.Request.HttpMethod == "POST")
			{
				HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			}
		}
	}
