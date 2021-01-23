        public string GetPageUrl(Guid pageId, CultureInfo locale)
        {
            using(var conn = new DataConnection(PublicationScope.Published, locale))
            {
                var pageNode = new SitemapNavigator(conn).GetPageNodeById(pageId);
                return pageNode != null ? pageNode.Url : null;
            }
        }
