     private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
                    {
                        if (webBrowser1.Document != null)
                        {
                            webBrowser1.Document.MouseDown += Document_MouseDown;
                        }
                    }
           
     private void Document_MouseDown(object sender, HtmlElementEventArgs e)
                {
                    if (e.MouseButtonsPressed == System.Windows.Forms.MouseButtons.Middle)
                    {
                        e.ReturnValue = false;
        
                        // Your custom code
                    }
                }
