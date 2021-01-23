    public void ClickButton(string type) {
        var button = myWebBrowser.Document.GetElementsByTagName("button")
                 .Cast<HtmlElement>()
                 .FirstOrDefault(m => m.GetAttribute("type") == type);
        if (button != null)
            button.InvokeMember("click"); 
    }
