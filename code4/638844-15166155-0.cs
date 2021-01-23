            XDocument doc = XDocument.Load(@"Data.xml");
            var elements = doc.Root
                .Elements("post")
                .Select(post => post
                                .Elements("price")
                                .OrderBy(price => Convert.ToDecimal(price.Element("cost").Value))
                                .First())
                .Select(post => 
                    new { 
                        Post = post,
                        Provider = post.Element("provider"),
                        Cost = post.Element("cost")
                    });
