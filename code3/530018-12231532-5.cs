    private void AssignEvents()
    {
      Navigated += myWeb_Navigated;
      DocumentCompleted += myWeb_DocumentCompleted;
      Navigating += myWeb_Navigating;
      NewWindow += myWeb_NewWindow;
      DownloadComplete += myWen_DownloadComplete;
    }
    void myWen_DownloadComplete(object sender, EventArgs e)
    {
      // Check wheter the document is available (it should be)
      if (Document != null)
        // Subscribe to the Error event
        Document.Window.Error += myWeb_Window_Error;
    }
    void myWeb_Window_Error(object sender, HtmlElementErrorEventArgs e)
    {
      // We got a script error, record it
      ScriptErrorManager.Instance.RegisterScriptError(e.Url, 
                               e.Description, e.LineNumber);
      // Let the browser know we handled this error.
      e.Handled = true;
    }
