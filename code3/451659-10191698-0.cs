    if (node.InnerHtml == String.Empty) {
        HtmlNode parent = node.ParentNode;
        if (parent == null) {
            parent = doc.DocumentNode;
        }
        parent.RemoveChild(node);
    }
