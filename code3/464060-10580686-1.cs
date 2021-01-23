    string htmlCode = "";
    using (WebClient client = new WebClient())
    {
    client.Headers.Add(HttpRequestHeader.UserAgent, "AvoidError");
    htmlCode = client.DownloadString("http://www.website.com");
    }
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    
    doc.LoadHtml(htmlCode);
    
    DataTable dt = new DataTable();
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Value", typeof(decimal));
    
    int count = 0;
    decimal rowValue = 0;
    bool isDecimal = false;
    foreach (var row in doc.DocumentNode.SelectNodes("//table[@summary='Table Name']/tbody/tr"))
    {
    DataRow dr = dt.NewRow();
    foreach (var cell in row.SelectNodes("td"))
    {
    if ((count % 2 == 0))
    {
    dr["Name"] = cell.InnerText.Replace("&nbsp;", " ");
    }
    else
    {
    isDecimal = decimal.TryParse((cell.InnerText.Replace(".", "")).Replace(",", "."), out rowValue);
    if (isDecimal)
    {
    dr["Value"] = rowValue;
    }
    dt.Rows.Add(dr);
    }
    count++;
    }
    }
