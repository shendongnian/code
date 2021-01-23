    class MyClient
    {    
        ManualResetEvent mre = new System.Threading.ManualResetEvent();
    
        public MyClient(WebBrowser wb)
        {
            webBrowser = wb;    
            webBrowser.DocumentCompleted += (sender, e) =>
            {
                if (e.Url == webBrowser.Url)  // are these equal after navigation?
                {
                    mre.Set();
                }
            };
         }
    
        private void Navigate(string url)
        {
             mre.Reset();
             webBrowser.Navigate(url);
             mre.WaitOne();
        }
    }
   
