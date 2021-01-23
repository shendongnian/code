    private static readonly Regex HtmlEntityRegex = new Regex("&(#)?([a-zA-Z0-9]*);");
    public static string HtmlDecode(this string html)
    {
        if (html.IsNullOrEmpty()) return html;
        return HtmlEntityRegex.Replace(html, x => x.Groups[1].Value == "#"
            ? ((char)int.Parse(x.Groups[2].Value)).ToString()
            : HttpUtility.HtmlDecode(x.Groups[0].Value));
    }
    [Test]
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase("&#39;fark&#39;", "'fark'")]
    [TestCase("&quot;fark&quot;", "\"fark\"")]
    public void should_remove_html_entities(string html, string expected)
    {
        html.HtmlDecode().ShouldEqual(expected);
    }
