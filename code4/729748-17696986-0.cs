    webBrowser1.Navigate(url);
    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
    {
        Application.DoEvents();
    }
    // assign the button to a variable
    var button = webBrowser1.Document.GetElementById("downloadButton");
    // attach an event handler for the 'onclick' event of the button
    button.AttachEventHandler("onclick", (a, b) =>
    {
        // use the Microsoft Internet Controls COM library
        var shellWindows = new SHDocVw.ShellWindows();
        // get the location of the last window in the collection
        var newLocation = shellWindows.Cast<SHDocVw.InternetExplorer>()
            .Last().LocationURL;
        // navigate to the newLocation
        webBrowser1.Navigate(newLocation);
        while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        {
            Application.DoEvents();
        }
        // get the document's source
        var source = webBrowser1.DocumentText;
    });
    button.InvokeMember("click");
