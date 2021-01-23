    private void ChangeDocument(string documentText, double timeout)
            {
                System.DateTime startTime = System.DateTime.Now;
                double elapsed = 0;
    
                if (webBrowser1.Document == null)
                {
                    webBrowser1.Navigate("about:blank");
                }
    
                webBrowser1.Document.OpenNew(false);
    
                while ((webBrowser1.DocumentText != "") && (elapsed < timeout))
                {
                    System.Threading.Thread.Sleep(50);
                    elapsed = System.DateTime.Now.Subtract(startTime).TotalMilliseconds;
                }
    
                webBrowser1.Document.Write(documentText);
                //webBrowser1.DocumentText = documentText;
    
                startTime = System.DateTime.Now;
                elapsed = 0;
    
                while ((webBrowser1.DocumentText != documentText) && (elapsed < timeout))
                {
                    System.Threading.Thread.Sleep(50);
                    elapsed = System.DateTime.Now.Subtract(startTime).TotalMilliseconds;
                }
            }
