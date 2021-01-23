     webBrowser1.DocumentCompleted += (d1, d2) => 
                    {
                       
    
                        string urlCurrent = d2.Url.ToString();
                        var browser = (WebBrowser)d1;
    
                        if (!(urlCurrent.StartsWith("http://") || urlCurrent.StartsWith("https://")))
                        {
                            // in AJAX     
                        }
                        if (d2.Url.AbsolutePath != browser.Url.AbsolutePath)
                        {
                            // IFRAME           
                        }
                        else
                        {
                            // REAL DOCUMENT COMPLETE
  
                            Debug.WriteLine("DocumentCompleted " + DateTime.Now.TimeOfDay.ToString());
                        }
    
                    };
