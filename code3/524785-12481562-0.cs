    private static void RemoveElementKeepText(HtmlNode node)
        {
            //node.ParentNode.RemoveChild(node, true);
            HtmlNode parent = node.ParentNode;
            HtmlNode prev = node.PreviousSibling;
            HtmlNode next = node.NextSibling;
            foreach (HtmlNode child in node.ChildNodes)
            {
                if (prev != null)
                    parent.InsertAfter(child, prev);
                else if (next != null)
                    parent.InsertBefore(child, next);
                else
                    parent.AppendChild(child);
            }
            node.Remove();
        }
