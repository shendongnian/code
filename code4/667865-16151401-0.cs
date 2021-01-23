    // Create a webclient.
    WebClient webClient = new WebClient(BrowserVersion.FIREFOX_17)
        {
            JavaScriptEnabled = true
            ThrowExceptionOnScriptError = false,
            ThrowExceptionOnFailingStatusCode = false,
        };
    webClient.WaitForBackgroundJavaScript(5000);
    HtmlPage htmlPage = webClient.GetHtmlPage(url);
    // Return the page for the given URL as Text.
    return htmlPage.WebResponse.ContentAsString;
