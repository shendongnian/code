    HtmlWeb web = new HtmlWeb();
    HtmlAgilityPack.HtmlDocument doc =
        web.Load("http://search.freefind.com/siteindex.html?id=59478474&ltr=10240&fwr=0&pid=i&ics=1");
    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//font[@class='search-index-font']");
    string link = string.Empty;
    if (nodes != null)
    {
        foreach (var item in nodes)
        {
            var value =
            nodes[0].Elements("script").ToList();
            foreach (var items in value)
            {
                link += items.NextSibling.InnerText+ "\n";
            }
        }
        MessageBox.Show(link);
    }
    else
        MessageBox.Show("no wordfound ");
