    private IList<Foo> GetFeatureSubCategories(HtmlNode std, Foo category)
    {
        List<Category> categories = new List<Category>();
        {
            if (category.Name == "Featured")
            {
                var nodes = std.SelectNodes("//span[contains(@class,'widget')] [position() <= 4]");
                foreach (var node in nodes)
                {
                   // blah ...
                }
                // blah ...
            }
        }
        return categories;
    }
