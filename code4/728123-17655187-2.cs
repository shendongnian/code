    class MyClient
    {    
        Form frm;
           
        public MyClient(WebBrowser wb)
        {
            frm = (Form) wb.Parent;  // assume WebBrowser is directly on the form
            webBrowser = wb;    
            webBrowser.DocumentCompleted += (sender, e) =>
            {
               frm.Invoke( new MethodInvoker( () => frm.Enabled = true ));   
               // you can can Invoke other methods if you like form here        
            };
         }
    
        private void Navigate(string url)
        {
             webBrowser.Navigate(url);
             frm.Enabled = false;
        }
    }
   
