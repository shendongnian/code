    private IList<Category> GetFeatureSubCategories(HtmlNode std, Category category)
    {
        List<Category> categories = new List<Category>();
        {
            if (category.name == "Featured")
            {
                var nodes = std.SelectNodes("//span[contains(@class,'widget')] [position() <= 4]");
                foreach (var node in nodes)
                {
                    string name = SiteParserUtilities.ParserUtilities.CleanText(System.Net.WebUtility.HtmlDecode(node.InnerText));
                    string url = node.Attributes["href"].Value;
                    string identifier = url.Split('/').Last().Replace(".html", "");
                    WriteQueue.write(string.Format(" Category [{0}].. {1} ", name, url));
                    IList<Category> sub = GetSubCategories(std);
                    Category c = new Category()
                    {
                        active = true,
                        Categories = sub.ToArray(),
                        description = "",
                        identifier = identifier,
                        name = name,
                        Products = new Product[0],
                        url = url,
                    };
                    StatisticCounters.CategoriesCounter();
                    categories.Add(c);
                }
            }
        }
             return categories;
    }
