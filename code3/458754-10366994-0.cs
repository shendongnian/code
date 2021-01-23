            private void Form1_Load(object sender, EventArgs e)
            {
                var rawData = "<p><span>Child Text </span><span class=\"price\">Child Text</span><br />I need this text</p>";
                var html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(rawData);
                html.DocumentNode.SelectNodes("//p/span[@class=\"price\"]").ToList().ForEach(x=>MessageBox.Show(x.InnerText));
            }
