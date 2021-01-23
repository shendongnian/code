            XDocument doc = XDocument.Load(@"Data.xml");
            var elements = doc.Root
                .Elements("post")
                .Select(post => new
                {
                    Post = post,
                    Price = post
                            .Elements("price")
                            .OrderBy(price => Convert.ToDecimal(price.Element("cost").Value))
                            .First()
                })
                .Select(o =>
                    new
                    {
                        Author = o.Post.Element("author").Value,
                        Subject = o.Post.Element("subject").Value,
                        Uploaded = Convert.ToDateTime(o.Post.Element("dates").Element("uploaded").Value),
                        Published = Convert.ToDateTime(o.Post.Element("dates").Element("published").Value),
                        Provider = o.Price.Element("provider").Value,
                        Cost = Convert.ToDecimal(o.Price.Element("cost").Value)
                    });
            var p = elements.First();
