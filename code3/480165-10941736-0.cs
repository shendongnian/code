            var url = "http://ytcracker.com/music/";
            var sr = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream());
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(sr.ReadToEnd());
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.EndsWith(".mp3"))
                {
                    MessageBox.Show("http://www.ytcracker.com/music/" + att.Value);
                    using (var client = new WebClient())
                    {
                        client.DownloadFile("http://www.ytcracker.com/music/" + att.Value, @"C:\Users\Lavi\Downloads\downloadto\.mp3");
                    }
                }
            }
