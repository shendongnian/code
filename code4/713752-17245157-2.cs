    public class ParsResult
    {
        public ParsResult Parent { get; set; }
        public String Url { get; set; }
        public Int32 Depth { get; set; }
    }
__
    private readonly List<ParsResult> _results = new List<ParsResult>();
    private  Int32 _maxDepth = 5;
    public  void Foo(String urlToCheck = null, Int32 depth = 0, ParsResult parent = null)
    {
        if (depth >= _maxDepth) return;
        String html;
        using (var wc = new WebClient())
            html = wc.DownloadString(urlToCheck ?? parent.Url);
 
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        var aNods = doc.DocumentNode.SelectNodes("//a");
        if (aNods == null || !aNods.Any()) return;
        foreach (var aNode in aNods)
        {
            var url = aNode.Attributes["href"];
            if (url == null)
                continue;
            var result = new ParsResult
            {
                Depth = depth,
                Parent = parent,
                Url = url.Value
            };
            _results.Add(result);
            Console.WriteLine("{0} - {1}", depth, result.Url);
            Foo(depth: depth + 1, parent: result);
    }
