      private static Doc CreateNewDoument(string currentURL)
            {
                var theDoc = new Doc();
    
                theDoc.MediaBox.String = "A4";
    
                theDoc.HtmlOptions.PageCacheEnabled = false;
                theDoc.HtmlOptions.ImageQuality = 101;
                theDoc.Rect.Width = 719;
                theDoc.Rect.Height = 590;
                theDoc.Rect.Position(2, 70);
                theDoc.HtmlOptions.Engine = EngineType.Gecko;
        
                // Add url to document.););
                try
                {
                    //Make sure we dont have a cached page.. 
                    string pdfUrl = currentURL+ "&discache=" + DateTime.Now.Ticks.ToString();
    
                    int theID = theDoc.AddImageUrl(pdfUrl);
                    //Add up to 50 pages
                    for (int i = 1; i <= 50; i++)
                    {
                        if (!theDoc.Chainable(theID))
                            break;
                        theDoc.Page = theDoc.AddPage();
                        theID = theDoc.AddImageToChain(theID);
                    }
                    theDoc.PageNumber = 1;
                }
                catch (Exception ex)
                {
                    //HttpContext.Current.Response.Redirect(pdCurrentURL);
    
                    throw new ApplicationException("Error generating pdf..." + "Exception: " + ex + "<br/>URL for render: " + pdfUrl+ "<br/>Base URL: " + currentURL);
                }
    
                return theDoc;
            }
