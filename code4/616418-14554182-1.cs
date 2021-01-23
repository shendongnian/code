    public static void RemoveChildKeepGrandChildren(HtmlNode parent, HtmlNode oldChild)
    {
        if (oldChild.ChildNodes != null)
        {
            HtmlNode previousSibling = oldChild.PreviousSibling;
            foreach (HtmlNode newChild in oldChild.ChildNodes)
            {
                parent.InsertAfter(newChild, previousSibling);
                previousSibling = newChild;  // Missing line in HtmlAgilityPack
            }
        }
        parent.RemoveChild(oldChild);
    }
