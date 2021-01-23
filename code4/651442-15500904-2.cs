    public enum ControlVisibility
    {
        Hidden,
        Partial,
        Full,
        FullHeightPartialWidth,
        FullWidthPartialHeight
    }
    /// <summary>
    /// Checks to see if an object is rendered visible within a parent container
    /// </summary>
    /// <param name="child">UI element of child object</param>
    /// <param name="parent">UI Element of parent object</param>
    /// <returns>ControlVisibility Enum</returns>
    public static ControlVisibility IsObjectVisibleInContainer(
        FrameworkElement child, UIElement parent)
    {
        GeneralTransform childTransform = child.TransformToAncestor(parent);
        Rect childSize = childTransform.TransformBounds(
            new Rect(new Point(0, 0), new Point(child.Width, child.Height)));
        Rect result = Rect.Intersect(
            new Rect(new Point(0, 0), parent.RenderSize), childSize);
        if (result == Rect.Empty)
        {
            return ControlVisibility.Hidden;
        }
        if (result.Height == childSize.Height && result.Width == childSize.Width)
        {
            return ControlVisibility.Full;
        }
        if (result.Height == childSize.Height)
        {
            return ControlVisibility.FullHeightPartialWidth;
        }
        if (result.Width == childSize.Width)
        {
            return ControlVisibility.FullWidthPartialHeight;
        }
        return ControlVisibility.Partial;
    }
