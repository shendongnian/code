    public HtmlDocument Download(string url)
        {
            HtmlDocument hdoc = new HtmlDocument();
            HtmlNode.ElementsFlags.Remove("option");
            HtmlNode.ElementsFlags.Remove("select");
            Stream read = null;
            try
            {
                read = wc.OpenRead(url);
            }
            catch (ArgumentException)
            {
                read = wc.OpenRead(HttpHelper.HTTPEncode(url));
            }
            hdoc.Load(read, true);
            return hdoc;
        }
