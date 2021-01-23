    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      var loginControl = webBrowser1.Document.GetElementById("login");
      var passwordControl = webBrowser1.Document.GetElementById("password");
      if (loginControl != null)
        loginControl.SetAttribute("value", "something");
      if (passwordControl != null)
        passwordControl.SetAttribute("value", "something");
    }
