    public class FixedWidthComboBox : ComboBox
    {
        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(new Size(ActualWidth, constraint.Height));
        }
    }
