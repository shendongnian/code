    public class SelectListItem
    {
          public string Value { set; get; }
          public string Text { set; get; }
          public List<ImageUrl> Images { set; get; }
    }
    public class ImageUrl
    {
          public string Url { set; get; }
          public string Description { set; get; }
    }
        
    public List<ImageUrl> GetImgUrl(IEnumerable<XElement> list)
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
    var category =
                  from symbolCategory in XDocument.Load(imageFile).Descendants("Category")
                        select new SelectListItem
                        {
                            Value = symbolCategory.Attribute("id").Value,
                            Text = symbolCategory.Attribute("name").Value,
                            Images = GetImgUrl(symbolCategory.Descendants("image"))
                        };
