    private void updateNews()
    {
           //Get data from xml url (This is the code that shuld not run everytime a user visits the view)
            var url = "http://www.interneturl.com/file.xml";
            XNamespace dcM = "http://search.yahoo.com/mrss/";
            var xdoc = XDocument.Load(url);
            var items = xdoc.Descendants("item")
            .Select(item => new
            {
                Title = item.Element("title").Value,
                Description = item.Element("description").Value,
                Link = item.Element("link").Value,
                PubDate = item.Element("pubDate").Value, 
                MyImage = (string)item.Elements(dcM + "thumbnail")
               .Where(i => i.Attribute("width").Value == "144" && i.Attribute("height").Value == "81")
               .Select(i => i.Attribute("url").Value)
               .SingleOrDefault()
            })
            .ToList();
            //Fill my db entities with the xml data(This is the code that shuld not run everytime a user visits the view)
            foreach (var item in items)
            {
                var date = DateTime.Parse(item.PubDate);
                if (!item.Title.Contains(":") && !(date <= DateTime.Now.AddDays(-1)))
                    {
                        News NewsItem = new News();
                        Category Category = new Category();
                        var CategoryID = 2;
                        var WorldCategoryID = re.GetByCategoryID(CategoryID);
                        NewsItem.Category = WorldCategoryID;
                        NewsItem.Description = item.Description;
                        NewsItem.Title = item.Title.Replace("'", "");
                        NewsItem.Image = item.MyImage;
                        NewsItem.Link = item.Link;
                        NewsItem.Date = DateTime.Parse(item.PubDate);
                        re.AddNews(NewsItem);
                        re.save();
                    }
                }
    }
