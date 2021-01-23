    foreach (var item in doc.DocumentNode.SelectNodes("//removeMe"))
    {
        if (item.PreviousSibling == null)
        {
            //First element -> so add it at beginning of the parent's innerhtml
            item.ParentNode.InnerHtml = item.InnerHtml + item.ParentNode.InnerHtml;
        }
        else
        {
            //There is an element before itemToRemove -> add the innerhtml after the previous item
            foreach(HtmlNode node in item.ChildNodes){
                item.PreviousSibling.ParentNode.InsertAfter(node, item.PreviousSibling);
            }
        }
        item.Remove();
    }
