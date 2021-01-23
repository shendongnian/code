     string url = "http://www.ta-meteo.fr/troyes.htm";
     Encoding iso = Encoding.GetEncoding("iso-8859-1");
       HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = iso,
            };
       HtmlDocument doc = web.Load(url);
       HtmlNode bulletinMatin = doc.DocumentNode.SelectSingleNode("//*[@id='blockdetday0']/div[1]/p[1]");
       MessageBox.Show(bulletinMatin.InnerText);     
