    public ActionResult Index()
        {
            List<MySelectListItem> category =
              (from symbolCategory in XDocument.Load("d:\\data.xml").Descendants("Category")
               select new MySelectListItem
               {
                   Value = symbolCategory.Attribute("id").Value,
                   Text = symbolCategory.Attribute("name").Value,
                   Images = GetImgUrl(symbolCategory.Descendants("image"))
               }).ToList();
            return View(category);
        }
        private List<ImageUrl> GetImgUrl(IEnumerable<XElement> list)
        {
            List<ImageUrl> retVal = new List<ImageUrl>();
            foreach (XElement el in list)
            {
                ImageUrl url = new ImageUrl();
                url.Description = el.Attribute("desc").Value;
                url.Url = el.Attribute("url").Value;
                retVal.Add(url);
            }
            return retVal;
        }
