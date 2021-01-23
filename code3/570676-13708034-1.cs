    public static readonly DependencyProperty HeaderDrawingVisualProperty = DependencyProperty.Register("HeaderDrawingVisual", typeof(MyVisualHost), typeof(MainWindow));
    public MyVisualHost VisualHost
    {
        get { return (MyVisualHost)GetValue(HeaderDrawingVisualProperty); }
        set { SetValue(HeaderDrawingVisualProperty, value); }
    }
