    private Geometry textGeometry;
        
    protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
    {
        if (textGeometry == null)
        {
            var currentTypeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            var formattedText = new FormattedText(Text
                , System.Globalization.CultureInfo.CurrentCulture
                , System.Windows.FlowDirection.LeftToRight
                , currentTypeface
                , FontSize
                , Foreground
                );
            var d = LineHeight - formattedText.Baseline;
            textGeometry = formattedText.BuildGeometry(new Point(-formattedText.OverhangLeading, d));
            textGeometry.Freeze();
            this.InvalidateMeasure();
            this.InvalidateArrange();
        }
        drawingContext.DrawGeometry(Foreground, null, textGeometry);
    }
