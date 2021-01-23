        [WebMethod()]     
        public List<Deal> GetDeals()
        {
            var deals = new List<Deal>();
            XmlReader xr = XmlReader.Create("http://www.hotukdeals.com/rss/hot");
            SyndicationFeed feed = SyndicationFeed.Load(xr);
            foreach (var item in feed.Items)
            {
                deals.Add(new Deal { Title = item.Title.Text, Summary = item.Summary.Text });
            }
            return deals;
        }
