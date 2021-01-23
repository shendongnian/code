        private double MeasureText(string text, FontFamily font, double fontsize)
        {
            var mesureLabel = new TextBlock(); 
            mesureLabel.FontFamily = font;
            mesureLabel.FontSize = fontsize; 
            mesureLabel.Text = text; 
            mesureLabel.Padding = new Thickness(0); 
            mesureLabel.Margin = new Thickness(0); 
            mesureLabel.Width = double.NaN; 
            mesureLabel.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity)); 
            mesureLabel.Arrange(new Rect(mesureLabel.DesiredSize));
            return mesureLabel.ActualWidth;
        }
