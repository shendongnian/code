    public ActionResult Scrap()
     {
        var webGet = new HtmlWeb();
        var document = webGet.Load(Url);
        var wikians = from info in document.DocumentNode.SelectNodes("//div[@id='results']")
                      from link in info.SelectNodes("p//a").Where(x => x.Attributes.Contains("href"))
                      from content in info.SelectNodes("p").Where(y => y.HasAttributes != true)
                      select new WikiModel
                        {
                          LinkURL = link.Attributes["href"].Value,
                          Text = content.InnerText                             
                        };
    
     return View((List<WikiModel>)wikians);
    }
