    public class CultureModule:IHttpModule
	{
		public void Dispose()
		{		   
		}
		public void Init(HttpApplication context)
		{
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);			
		}
        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var requestUri = HttpContext.Current.Request.Url.AbsoluteUri;
            /// Your logic to get the culture.
            /// I am reading from uri for a region
            CultureInfo currentCulture;
            if (requestUri.Contains("cs"))
                currentCulture = new System.Globalization.CultureInfo("cs-CZ");
            else if (requestUri.Contains("fr"))
                currentCulture = new System.Globalization.CultureInfo("fr-FR");
            else
                currentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
        }
        
	}
