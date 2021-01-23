    public class MyStackPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Size newSize = new Size();
            UIElement firstChild = Children[0];
            UIElement secondChild = Children[1];
            secondChild.Measure(availableSize);
            firstChild.Measure(new Size(availableSize.Width - secondChild.DesiredSize.Width, availableSize.Height));
            newSize.Width = firstChild.DesiredSize.Width + secondChild.DesiredSize.Width;
            newSize.Height = firstChild.DesiredSize.Height;
            return newSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            UIElement firstChild = Children[0];
            UIElement secondChild = Children[1];
            firstChild.Arrange(new Rect(0, 0, firstChild.DesiredSize.Width, firstChild.DesiredSize.Height));
            secondChild.Arrange(new Rect(firstChild.DesiredSize.Width, 0, secondChild.DesiredSize.Width,
                                         firstChild.DesiredSize.Height));
            return base.ArrangeOverride(finalSize);
        }
    }
