            public void MyParsing()
        {
            const string baseUrl = "http://udokan.chita.ru/";
            var htmlDoc = new HtmlDocument();
            var webClient = new WebClient();
            htmlDoc.LoadHtml(webClient.DownloadString(baseUrl));
            var htmlNodeCollection = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
            if (htmlNodeCollection != null)
            {
                foreach (var link in htmlNodeCollection)
                {
                    try
                    {
                        if(link.Attributes["href"].Value.Contain("repert"))
                        {
                        var newUrl = new Uri(new Uri(baseUrl), link.Attributes["href"].Value).AbsoluteUri;
                        var queries = HttpUtility.ParseQueryString(string.Join(string.Empty, newUrl.Split('?').Skip(1)));
                        var id = queries["id"];
                        richTextBox1.AppendText(id);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
