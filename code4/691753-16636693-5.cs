    byte[] pageBytes;
    using (var client = new WebClient())
    {
      pageBytes = client.DownloadData(url);
    }
    HtmlDocument page = new HtmlDocument();
    using (var ms = new MemoryStream(pageBytes))
    {
      page.Load(ms);
      var metaContentType = page.DocumentNode.SelectSingleNode("//meta[@http-equiv='Content-Type']").GetAttributeValue("content", "");
      var contentType = new System.Net.Mime.ContentType(metaContentType);
      ms.Position = 0;
      page.Load(ms, Encoding.GetEncoding(contentType.CharSet));
    }
