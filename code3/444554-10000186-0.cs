    public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(double),
        typeof(Marquee), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    //
    public double Offset {
        get { return (double)GetValue(OffsetProperty); }
    }
    protected override void OnRender(DrawingContext dc) {
        dc.DrawText(currentText, new Point(Offset, 0)); // direct render
    }
    int nextTextIndex = 0;
    FormattedText currentText;
    void GetNextText() {
        if(formattedTexts.Count == 0) return;
        currentText = formattedTexts[(nextTextIndex++) % formattedTexts.Count];
    }
    void CreateAnimation() {
        if(CurrentString == null)
            return;
        GetNextText();
        double width = currentText.Width;
        double secs = (Application.Current.MainWindow.ActualWidth + width) / Rate;
        duration = new Duration(TimeSpan.FromSeconds(secs));
        anim = new DoubleAnimation(0, -width, duration);
        anim.Completed += anim_Completed;
        BeginAnimation(OffsetProperty, anim);
    }
    //
    void anim_Completed(object sender, EventArgs e) {
        anim.Completed -= anim_Completed;
        CreateAnimation();
    }
    List<FormattedText> formattedTexts = new List<FormattedText>();
    void CreateTexts() {
        foreach(var line in Lines) {
            FormattedText ft = new FormattedText(line,
                System.Globalization.CultureInfo.CurrentUICulture,
                System.Windows.FlowDirection.LeftToRight,
                new Typeface(FontFamily.Source),
                FontSize,
                FontBrush);
    
            if(ft.Height == 0 || ft.Width == 0)
                continue;
            formattedTexts.Add(ft);
        }
    }
