    public class MyPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            foreach (UIElement child in Children)
            {
                child.Measure(infiniteSize); // allow unconstrained child size
            }
            return new Size(); // consume as less size as possible
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var position = new Point();
            foreach (UIElement child in Children)
            {
                var size = child.DesiredSize;
                child.Arrange(new Rect(position, size));
                position.X += size.Width;
                position.Y += size.Height;
            }
            return new Size(position.X, position.Y);
        }
    }
