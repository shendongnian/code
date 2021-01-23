    private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    		{
    			if (Program.BrowsingSystem.BrowserLink.ReadyState == WebBrowserReadyState.Complete)
    			{
    				lock (Program.BrowsingSystem.BrowserLocker)
    				{
    					Program.BrowsingSystem.ActualPosition = Program.BrowsingSystem.UpdatePosition(Program.BrowsingSystem.Document);
    					Program.BrowsingSystem.CheckContentAvailability();
    					Program.BrowsingSystem.IsBusy = false;
    				}
    			}
    		}
    private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    		{
    			lock (Program.BrowsingSystem.BrowserLocker)
    			{
    				Program.BrowsingSystem.ActualPosition.PageName = OgamePages.OnChange;
    				Program.BrowsingSystem.IsBusy = true;
    			}
    		}
