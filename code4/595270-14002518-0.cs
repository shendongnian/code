    public class SquareDecorator : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if( Children.Count == 0 )   return base.MeasureOverride(availableSize);
            if( Children.Count > 1 )    throw new ArgumentOutOfRangeException("SquareDecorator should have one child");
            
            Children[0].Measure(availableSize);
            var sideLength = Math.Max(Children[0].DesiredSize.Width, Children[0].DesiredSize.Height);
            return new Size(sideLength, sideLength);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            if( Children.Count == 0 )   return base.ArrangeOverride(finalSize);
            if( Children.Count > 1 )    throw new ArgumentOutOfRangeException("SquareDecorator should have one child");
            double sideLength = Math.Min(finalSize.Width, finalSize.Height);
            Children[0].Arrange(new Rect(0, 0, sideLength, sideLength));
            return new Size(sideLength, sideLength);
        }
    }
