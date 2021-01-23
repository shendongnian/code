    var htmlDoc = new HtmlDocument();
    
    // load html
    htmlDoc.LoadHtml(html);
    
    var tags = (from tag in htmlDoc.DocumentNode.Descendants()
               where tagNames.Contains(tag.Name)
               select tag).Reverse();
    
    // find formatting tags
    foreach (var item in tags)
    {
        if (item.PreviousSibling == null)
        {
            // Prepend children to parent node in reverse order
            foreach (HtmlNode node in item.ChildNodes.Reverse())
            {
                item.ParentNode.PrependChild(node);
            }                        
        }
        else
        {
            // Insert children after previous sibling
            foreach (HtmlNode node in item.ChildNodes)
            {
                item.ParentNode.InsertAfter(node, item.PreviousSibling);
            }
        }
    
        // remove from tree
        item.Remove();
    }
    
    // return transformed doc
    html = htmlDoc.DocumentNode.WriteContentTo().Trim();
