    HtmlDocument html = new HtmlDocument();
    html.Load(html_file);
    var odds = from ul in html.DocumentNode.Descendants("ul")
               let sibling = ul.NextSibling
               where sibling != null && 
                     sibling.NodeType == HtmlNodeType.Text && // check if text node
                     !String.IsNullOrWhiteSpace(sibling.InnerHtml)
               select sibling.InnerHtml.Trim();
