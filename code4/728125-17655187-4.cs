    class MyClient
    {    
        Form frm;
        public MyClient(WebBrowser wb, MethodInvoker callback)
        {
            frm = (Form) wb.Parent;  // assume WebBrowser is directly on the form
            webBrowser = wb;    
            webBrowser.DocumentCompleted += (sender, e) =>
            {
               frm.Invoke( new MethodInvoker( () => frm.Enabled = true ));   
               frm.Invoke(callback);      
            };
         }
    
        private void Navigate(string url)
        {
             webBrowser.Navigate(url);
             frm.Enabled = false;
        }
    }
   
