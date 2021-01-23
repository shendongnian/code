    // this example pulls coca-cola's posts
    var _Uri = new Uri("http://www.facebook.com/feeds/page.php?format=rss20&id=40796308305");
    // including user agent, otherwise FB rejects the request
    var _Client = new HttpClient();
    _Client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    // fetch as string to avoid error
    var _Response = await _Client.GetAsync(_Uri);
    var _String = await _Response.Content.ReadAsStringAsync();
    // convert to xml (will validate, too)
    var _XmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
    _XmlDocument.LoadXml(_String);
    // manually fill feed from xml
    var _Feed = new Windows.Web.Syndication.SyndicationFeed();
    _Feed.LoadFromXml(_XmlDocument);
    // continue as usual...
    foreach (var item in _Feed.Items)
    {
        // do something
    }
