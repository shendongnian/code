    public static List<HtmlNode> GetTagsWithClass(string html,List<string> @class)
        {
            // LoadHtml(html);           
            var result = htmlDocument.DocumentNode.Descendants()
                .Where(x =>x.Attributes.Contains("class") && @class.Contains(x.Attributes["class"].Value)).ToList();          
            return result;
        }      
