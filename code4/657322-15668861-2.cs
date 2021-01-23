    private void ArrangeElement(UIElement element, Point position)
    {
        if (element is FrameworkElement)
        {
            switch (((FrameworkElement)element).HorizontalAlignment)
            {
                case HorizontalAlignment.Center:
                    position.X -= element.DesiredSize.Width / 2;
                    break;
                case HorizontalAlignment.Right:
                    position.X -= element.DesiredSize.Width;
                    break;
                default:
                    break;
            }
            switch (((FrameworkElement)element).VerticalAlignment)
            {
                case VerticalAlignment.Center:
                    position.Y -= element.DesiredSize.Height / 2;
                    break;
                case VerticalAlignment.Bottom:
                    position.Y -= element.DesiredSize.Height;
                    break;
                default:
                    break;
            }
        }
        element.Arrange(new Rect(position, element.DesiredSize));
    }
