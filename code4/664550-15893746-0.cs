    public class CustomGrid : Grid
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            availableSize = new Size(availableSize.Width + double.MaxValue, availableSize.Height + double.MaxValue);
            return base.MeasureOverride(availableSize);
        }
    }
