    var doc = new HtmlDocument();
    doc.Load(webClient.OpenRead(url)); // not exactly production quality
    var openGraph = new Dictionary<string, string>();
    foreach (var meta in doc.DocumentNode.SelectNodes("//meta"))
    {
        var property = meta["property"];
        var content = meta["content"];
        if (property != null && property.Value.StartsWith("og:"))
        {
            openGraph[property.Value]
                = content != null ? content.Value : String.Empty;
        }
    }
    // Supported by: YouTube, Vimeo, CollegeHumor, etc
    if (openGraph.ContainsKey("og:video"))
    {
        // 1. Get the MIME Type
        string mime;
        if (!openGraph.TryGetValue("og:video:type", out mime))
        {
            mime = "application/x-shockwave-flash"; // should error
        }
        // 2. Get width/height
        string _w, _h;
        if (!openGraph.TryGetValue("og:video:width", out _w)
         || !openGraph.TryGetValue("og:video:height", out _h))
        {
            _w = _h = "300"; // probably an error :)
        }
        int w = Int32.Parse(_w), h = Int32.Parse(_h);
        Console.WriteLine(
            "<embed src=\"{0}\" type=\"{1}\" width=\"{2}\" height=\"{3}\" />",
            openGraph["og:video"],
            mime,
            w,
            h);
    }
