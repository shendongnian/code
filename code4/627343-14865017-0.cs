      public async Task<bool> Commit()
            {
                try
                {
                    Browser = new WebBrowser { ScriptErrorsSuppressed = true };
        
                    Browser.Navigate(Server);
                    Browser.DocumentCompleted += DocumentCompleteMethod;
    
                   while (Browser.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
    
       //At this point you can access the document as it is sure to be loaded.
       string title = Browser.Document.Title;
        
        //HERE I WANNA RETURN TRUE,FALSE DEPENDING ON THE VALUE I WILL READ FROM THE WEB PAGE
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        
        private void DocumentCompleteMethod(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        
        }
