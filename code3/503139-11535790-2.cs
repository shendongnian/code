    News news = new News();
                news.DataSet.Add(new NewsItemCollection
                {
                    Section = "Section1",
                    Items = new ObservableCollection<NewsItem>
                        {
                            new NewsItem { Title = "Test1.1" },
                            new NewsItem { Title = "Test1.2" }
                        }
                });
                news.DataSet.Add(new NewsItemCollection
                {
                    Section = "Section2",
                    Items = new ObservableCollection<NewsItem>
                        {
                            new NewsItem { Title = "Test2.1" },
                            new NewsItem { Title = "Test2.2" }
                        }
                });
    
                var serialized = news.XmlSerialize();
                var deserialized = serialized.XmlDeserialize<News>();
