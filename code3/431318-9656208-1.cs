    [TestMethod]
    [ExpectedException(typeof(UriFormatException), "url should be well formatted.")]
    public void GetHtmlContent_ThrowsInvalidUriException_WhenUriIsInBadFormat()
    {
        HashSet<string> urls = new HashSet<string> { "ww.stackoverflow.com" };
        var contextManager = new ContentManager(urls);
 
        contextManager.GetHtmlContent();
    }
