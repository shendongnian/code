    static HandCursor()
    {
        Canvas.LeftProperty.OverrideMetadata(
            typeof(HandCursor),
            new FrameworkPropertyMetadata(
                (o, e) => ((HandCursor)o).LeftPropertyChanged((double)e.NewValue)));
        Canvas.TopProperty.OverrideMetadata(
            typeof(HandCursor),
            new FrameworkPropertyMetadata(
                (o, e) => ((HandCursor)o).TopPropertyChanged((double)e.NewValue)));
    }
    private void LeftPropertyChanged(double left)
    {
        ...
    }
    private void TopPropertyChanged(double top)
    {
        ...
    }
