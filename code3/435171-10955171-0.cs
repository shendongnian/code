    webView.LoadCompleted += ExecuteJavascript;
    
    WebCore.BaseDirectory = @"C:\Documents and Settings\ME\dummytests\codes\views";
    webView.LoadFile("base.html");
    
    
...
    private void ExecuteJavascript(object sender, EventArgs eventArgs)
    {
        JSValue param1 = new JSValue("nameItem");
        webView.CallJavascriptFunction("base", "other");
        webView.CallJavascriptFunction("base", "newItem", param1);
        webView.Focus();
    }
