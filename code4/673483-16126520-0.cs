    bool canNavigate;
    public void WebBrowser1Document_Click(object sender, HtmlElementEventArgs e)
            {    
                canNavigate=false;
                tempHtmlElement = webBrowser1.Document.ActiveElement;
                ...
                ...
                //At the End 
                canNavigate=true;
             }
    
        void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                do
                {
    Application.DoEvents(); Thread.Sleep(100);
                  
                } while (!canNavigate);
            }
