    public class class BrowserWrapper : IResourceInterceptor
    {
    	public BrowserWrapper()
    	{
    		WebCore.ResourceInterceptor = this;
    		//BrowserWrapper can contains WebBrowser or knows how to delegate him Naviagtion (Source property)
    	}
    	
        private readonly ConcurrentDictionary<Uri, string> headers = new ConcurrentDictionary<Uri, string>();
    
        public void Navigate(Uri uri, string additionalHeaders = null)
        {
            if (additionalHeaders != null) headers.AddOrUpdate(uri, additionalHeaders, (url, h) => h);
            //Navigation to browser (WebControl.Source = uri...)
        }
    
        ResourceResponse IResourceInterceptor.OnRequest(ResourceRequest request)
        {
            string h;
            if (headers.TryRemove(request.Url, out h))
            {
                var hs = h.Split(':');
                request.AppendExtraHeader(hs[0], hs[1]);
            }
            return null;
        }
    
        bool IResourceInterceptor.OnFilterNavigation(NavigationRequest request)
        {
            return false;
        }
    }
    
