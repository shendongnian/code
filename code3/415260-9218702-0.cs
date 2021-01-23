    private bool isElementVisible(WebBrowser web, string elementID)
    {
        var element = web.Document.All[elementID];
        if (element == null)
            throw new ArgumentException(elementID + " did not return an object from the webbrowser");
        // Calculate the offset of the element, all the way up through the parent nodes
        var parent = element.OffsetParent;
        int xoff = element.OffsetRectangle.X;
        int yoff = element.OffsetRectangle.Y;
        while (parent != null)
        {
            xoff += parent.OffsetRectangle.X;
            yoff += parent.OffsetRectangle.Y;
            parent = parent.OffsetParent;
        }
        // Get the scrollbar offsets
        int scrollBarYPosition = web.Document.GetElementsByTagName("HTML")[0].ScrollTop;
        int scrollBarXPosition = web.Document.GetElementsByTagName("HTML")[0].ScrollLeft;
        // Calculate the visible page space
        Rectangle visibleWindow = new Rectangle(scrollBarXPosition, scrollBarYPosition, web.Width, web.Height);
        // Calculate the visible area of the element
        Rectangle elementWindow = new Rectangle(xoff,yoff,element.ClientRectangle.Width, element.ClientRectangle.Height);
        if (visibleWindow.IntersectsWith(elementWindow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
