    public class CustomWebChromeClient : WebChromeClient
    {
        private Activity _context;
    
        public CustomWebChromeClient(Activity context)
        {
            _context = context;
        }
    
        public override void OnProgressChanged(WebView view, int newProgress)
        {
            base.OnProgressChanged(view, newProgress);
    
            _context.SetProgress(newProgress * 100);
        }
    }
