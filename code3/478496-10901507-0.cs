    public class MyTextBox :TextBox 
    {
        public bool ContentsBiggerThanTextBox()
        {
            Typeface typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch);
            FormattedText ft = new FormattedText(this.Text, System.Globalization.CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, typeface, this.FontSize, Brushes.Black);
            if (ft.Width > this.ActualWidth)
                return true;
            return false;
        }
    }
