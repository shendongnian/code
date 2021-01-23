    string settings = "";
    if (!this.Dispatcher.CheckAccess())
      this.Dispatcher.BeginInvoke(new Action(() => {
        settings = HtmlPage.Window.Invoke("ReadFile", new object[] { path1 }) as string)
        // use settings here ...
      }
    ) else {
        settings = HtmlPage.Window.Invoke("ReadFile", new object[] { path1 }) as string)
        // use settings here ...
    };
