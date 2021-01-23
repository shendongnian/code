    var urls = new List<Uri>();
    var url = new Uri("http://stackoverflow.com/questions/12131954/");
    using (var client = new WebClient())
    {
      var doc = new HtmlDocument();
      doc.Load(client.OpenRead(url));
      var links = doc.DocumentNode.SelectNodes("//a[contains(@href,'stackoverflow.com')]");
      foreach (var link in links)
      {
        var uri = new Uri(url, link.Attributes["href"].Value); //fixes relative Urls
        if (uri.Scheme.StartsWith("http"))
        {
          urls.Add(uri);
        }
      }
      Console.WriteLine(urls);
    }
