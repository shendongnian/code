    public void ClickButton(string type) {
    var buttons= myWebBrowser.Document.GetElementsByTagName("input");
        foreach (HtmlElement curElement in buttons) {
            if (curElement.GetAttribute("type").Equals(type)) {
                curElement.InvokeMember("click");
            }
        }
    }
