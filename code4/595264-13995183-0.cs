    public class SquareDecorator : ContentControl
    {
        public SquareDecorator()
        {
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalContentAlignment = VerticalAlignment.Stretch;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }
    
        protected override Size ArrangeOverride(Size finalSize)
        {
            double sideLength = Math.Min(finalSize.Width, finalSize.Height);
    
            var result = base.ArrangeOverride(new Size(sideLength, sideLength));
    
            return result;
        }
    }
