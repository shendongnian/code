    private SolidColorBrush _redBrush;
    private SolidColorBrush IndicatorRedBrush
    {
        get{ return _redBrush ?? (_redBrush = 
            Application.Current.FindResource("IndicatorRedBrush") as SolidColorBrush)); 
    }
    ... same for white brush
    public SolidColorBrush ShiftOverageBrush {
        get {
            if (ShiftOverage.HasValue && ShiftOverage.Value.Milliseconds < 0) {
                return IndicatorRedBrush;
            }
            return IndicatorWhiteBrush;
        }
    }
