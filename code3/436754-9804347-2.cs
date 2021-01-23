    private bool bCancel = false;
    private void webBrowser_DocumentCompleted(object sender,
                                     WebBrowserDocumentCompletedEventArgs e)
    {
      int i;
      for (i = 0; i < webBrowser.Document.Links.Count; i++)
      {
         webBrowser.Document.Links[i].Click += new    
                                HtmlElementEventHandler(this.LinkClick);
      }
    }
    private void LinkClick(object sender, System.EventArgs e)
    {
      bCancel = true;
      MessageBox.Show("Link Was Clicked Navigation was Cancelled");
    }
    private void webBrowser_Navingating(object sender, 
                                    WebBrowserNavigatingEventArgs e )
    {
      if (bCancel == true)
      {
         e.Cancel=true;
         bCancel = false;
      }
    }
