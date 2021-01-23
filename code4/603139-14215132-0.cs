    public class FeedModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Summary { get; set; }
    }
    public IEnumerable<FeedModel> GenerateModelFromRssFeed(string feedUri)
    {
        if (string.IsNullOrWhiteSpace(feedUri)) throw new ArgumentNullException(feedUri);
        using (var reader = XmlReader.Create(feedUri))
        {
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            if (feed == null) throw new ApplicationException("Bloomberg feed cannot be downloaded");
            return from item in feed.Items
                    select new FeedModel
                    {
                        // this looks a little ugly but is necessary to check if the object (Summary) is null as an 
                        // exception will be thrown when trying to access a property on a null object
                        Content = item.Summary == null ? string.Empty : item.Summary.Text,
                        Id = item.Id,
                        PublishDate = item.Summary == null ? DateTime.MaxValue : item.PublishDate.DateTime,
                        Title = item.Title == null ? string.Empty : item.Title.Text,
                        Link = item.Links.Any() ? item.Links.First().Uri.ToString() : string.Empty,
                        // add in additional logic to test if the element extension is not null
                        Summary = item.ElementExtensions.FirstOrDefault(x => x != null && x.GetObject<XElement>().Name.LocalName.ToLowerInvariant() == "summary").GetObject<XElement>().Value
                    };
        }
    }
