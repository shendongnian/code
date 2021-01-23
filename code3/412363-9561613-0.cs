    HtmlDocument htmlDoc = new HtmlDocument
            {
                OptionAddDebuggingAttributes = false,
                OptionAutoCloseOnEnd = true,
                OptionFixNestedTags = true,
                OptionReadEncoding = true
            };
            try
            {
                using (Stream reader = myHttpWebResponse.GetResponseStream())
                {
                    reader.Seek(0, SeekOrigin.Begin);
                    htmlDoc.Load(reader, true);
                }
                HtmlNode node = htmlDoc.DocumentNode;
                if (node != null)
                {
                    foreach (var href in doc.DocumentNode.Descendants("a").Select(x =>x.Attributes["href"]))
                     {
                         href.Value = "http://ahmadalli.somee.com/default.aspx?url=" +HttpUtility.UrlEncode(href.Value);
                     }
                }
            }
            catch { }
