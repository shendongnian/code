            XDocument doc = XDocument.Load(@"Data.xml");
            var elements = doc.Root
                .Elements("post")
                .Select(post => new
                {
                    Author = post.Element("author").Value,
                    Subject = post.Element("subject").Value,
                    Uploaded = Convert.ToDateTime(post.Element("dates").Element("uploaded").Value),
                    Published = Convert.ToDateTime(post.Element("dates").Element("published").Value),
                    Price = new
                    {
                        P = post
                            .Elements("price")
                            .OrderByDescending(price => Convert.ToDecimal(price.Element("cost").Value))
                            .Select(o => new
                            {
                                Provider = o.Element("provider").Value,
                                Cost = Convert.ToDecimal(o.Element("cost").Value)
                            })
                            .First()
                    }
                });
            var p = elements.First();
