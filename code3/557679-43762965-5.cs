            Private ReadOnly handleMouseEventJs As String =
    "
    function HandleMouseEvent(e) {
        var evt = (e==null ? event:e); 
        if (e.which == 2) e.preventDefault(); 
        return true;
    } 
    
    document.onmousedown = HandleMouseEvent;
    // These events below seems are not necessary to handle for this purpose.
    // document.onmouseup = HandleMouseEvent;
    // document.onclick   = HandleMouseEvent;
    "
    
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) _
    Handles WebBrowser1.Navigated
    
        Dim wb As WebBrowser = DirectCast(sender, WebBrowser)
        Dim doc As HtmlDocument = wb.Document
        Dim head As HtmlElement = doc.GetElementsByTagName("head")(0)
        Dim js As HtmlElement = doc.CreateElement("script")
        js.SetAttribute("text", handleMouseEventJs)
        head.AppendChild(js)
        ' This method call seems not necessary at all, it works fine without invocking it.
        ' Me.Document.InvokeScript("HandleMouseEvent", Nothing)
    
    End Sub
