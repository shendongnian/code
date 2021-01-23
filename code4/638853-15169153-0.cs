    var posts = from post in document.Root.Elements("post")
                select new
                {
                    Author = post.Element("author").Value,
                    Subject = post.Element("subject").Value,
                    Uploaded = DateTime.Parse(post.Element("dates").Element("uploaded").Value),
                    Published = DateTime.Parse(post.Element("dates").Element("published").Value),
                    Price = (from price in post.Elements("price")
                             let cost = decimal.Parse(price.Element("cost").Value)
                             orderby cost
                             select new
                             {
                                 Provider = price.Element("provider").Value,
                                 Cost = cost
                             }).First()
                };
