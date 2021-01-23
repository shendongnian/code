    reviews = from item in xmlDoc.Descendants("node") where item.Descendants().Any(n => n.Name == "Review")
                          select new ForewordReview()
                          {
                              PubDate = (string)item.Element("created"),
                              Isbn = (string)item.Element("isbn"),
                              Summary = (string)item.Element("review")
                          };
