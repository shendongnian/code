    [XmlRoot("feed")]
        public class News
        {
            [XmlArray("items")]
            public List<NewsItemCollection> DataSet { get; set; }
    
            public News()
            {
                DataSet = new List<NewsItemCollection>();
            }
        }
    
        public class NewsItemCollection
        {
            [XmlAttribute("section")]
            public string Section { get; set; }
    
            [XmlElement("item")]
            public ObservableCollection<NewsItem> Items { get; set; }
    
            public NewsItemCollection()
            {
                Items = new ObservableCollection<NewsItem>();
            }
        }
    
        public class NewsItem
        {
            public string Title { get; set; }
        }
