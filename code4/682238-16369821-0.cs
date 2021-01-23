    var url = @"http://www.technewsworld.com/perl/syndication/rssfull.pl";
    var xdoc = XDocument.Load(url);
    var v = xdoc.Descendants().Where(e => e.Name.LocalName == "item");
    var items = v.Select(item => new
                {
                    Title = item.Descendants().Where(e => e.Name.LocalName == "title").First().Value,
                    Description = item.Descendants().Where(e => e.Name.LocalName == "description").First().Value,
                    Link = item.Descendants().Where(e => e.Name.LocalName == "link").First().Value,
                    //PubDate = item.Descendants().Where(e => e.Name.LocalName == "dc:date").First().Value,
                    //MyImage = item.Descendants().Where(e => e.Name.LocalName == "content:encoded").First().Value,
                })
                .ToList();
