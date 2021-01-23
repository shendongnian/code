    protected override Size ArrangeOverride(Size finalSize)
        {
            return ArrangeByChildCount(finalSize);
        }
        private Size ArrangeByChildCount(Size finalSize)
        {
            double childWidth = 0;
            double childHeight = 0;
            foreach (UIElement e in Children)
            {
                e.Measure(finalSize);
                
                childWidth = e.DesiredSize.Width;
                childHeight = e.DesiredSize.Height;
            }
            if (Children.Count > 0)
            {
                int square = (int)Math.Sqrt(Children.Count);
                int rowCount = square + Children.Count % square;
                int columnCount = square;
                double height = rowCount * childHeight;
                double width = columnCount * childWidth;
                Size size = new Size(width, height);
                base.ArrangeOverride(size);
                return size;
            }
            else
            {
                return new Size(300, 300);
            }
        }
