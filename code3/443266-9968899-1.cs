    var rssFeed = XElement.Parse(e.Result);
    var currentFeed = this.DataContext as app.ViewModels.FeedViewModel;
    var items = from item in rssFeed.Descendants("item")                            
                select new ATP_Tennis_App.ViewModels.FeedItemViewModel()
                {
    
                    Title = RemoveHtmlTags(item.Element("title").Value),
                    DatePublished = DateTime.Parse(item.Element("pubDate").Value),
                    Url = item.Element("link").Value,
                    Description = RemoveHtml(item.Element("description").Value)
                };
