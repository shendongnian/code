    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.Load(new WebClient().OpenRead("http://www.nasdaq.com/quotes/nasdaq-100-stocks.aspx"));
    List<string> listStocks = new List<string>();
    HtmlNode scriptNode = htmlDoc.DocumentNode.SelectSingleNode("//script[contains(text(),'var table_body =')]");
    if (scriptNode != null)
    {
      //Using Regex here to get just the array we're interested in...
      string stockArray = Regex.Match(scriptNode.InnerText, "table_body = (?<Array>\\[.+?\\]);").Groups["Array"].Value;
      JArray jArray = JArray.Parse(stockArray);
      foreach (JToken token in jArray.Children())
      {
        listStocks.Add("http://www.nasdaq.com/symbol/" + token.First.Value<string>().ToLower());
      }
    }
