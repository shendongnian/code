    class CustomCanvas : Canvas
    {
        protected override void OnRender(DrawingContext dc)
        {
            FormattedText someFormattedText = new FormattedText(someText, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    someTypeFace, someFontSize, someColor);
            dc.DrawText(someFormattedText, new Point(15, 15));
        }
    }
