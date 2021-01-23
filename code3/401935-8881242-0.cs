    protected void Page_Load(object sender, EventArgs e)
    {
        XmlFeedItemPath xfip;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;
        List<string> xmlFeeds = appSettings.AllKeys.Where(x => x.StartsWith("XmlFeed")).ToList();
        string currentXmlFeedType;
        if(!string.IsNullOrEmpty(xmlFeedType))
            xmlFeeds.RemoveAll(s => !appSettings[s].Contains(XmlFeedType));
         
        xmlFeeds.ForEach(x =>
        {   
            currentXmlFeedType = XmlHelper.GetXmlFeedType(appSettings[x]);
            xfip = XmlHelper.GetXmlFeedItemPath(currentXmlFeedType);
            var request = (HttpWebRequest)WebRequest.Create(Server.UrlDecode(XmlHelper.GetXmlFeedUrl(appSettings[x])));
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            XPathNavigator xpn = new XPathDocument(XmlReader.Create(request.GetResponse().GetResponseStream())).CreateNavigator();
            XmlNamespaceManager xmlnsm = XmlHelper.GetXmlNameSpaceManager(xpn);
            XPathNodeIterator nodes = xpn.Select(xfip.IteratorPath, xmlnsm);
            int i = 0;
            foreach (XPathNavigator node in nodes)
            {
                string publishDate = string.IsNullOrEmpty(xfip.PublishDatePath) ? null : node.SelectSingleNode(xfip.PublishDatePath, xmlnsm).ToString();
                XmlFeedItems.Add(new XmlFeedItem()
                {
                    Title = string.IsNullOrEmpty(xfip.TitlePath) ? xfip.DefaultTitle : node.SelectSingleNode(xfip.TitlePath, xmlnsm).ToString(),
                    Link = string.IsNullOrEmpty(xfip.LinkPath) ? null : node.SelectSingleNode(xfip.LinkPath, xmlnsm).ToString(),
                    Teaser = string.IsNullOrEmpty(xfip.TeaserPath) ? null : XmlHelper.WrapUrlWithAnchorTags(HttpUtility.HtmlDecode(node.SelectSingleNode(xfip.TeaserPath, xmlnsm).ToString())),
                    Source = string.IsNullOrEmpty(xfip.SourcePath) ? null : xpn.SelectSingleNode(xfip.SourcePath, xmlnsm).ToString(),
                    SortOrder = i,
                    XmlFeedType = currentXmlFeedType,
                    PublishDate = string.IsNullOrEmpty(publishDate) ? new DateTime() : DateTime.Parse(publishDate.Remove(publishDate.IndexOf(" +")))
                });
                i++;
            }
        });
        rptRssFeed.DataSource = XmlFeedItems.OrderBy(x => x.GetType().GetProperty(sortField)).Take(10);
        rptRssFeed.DataBind();
    } 
