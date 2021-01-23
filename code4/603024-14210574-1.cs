    public MainWindow()
    {
        InitializeComponent();
        Grid myGrid = new Grid();
        BitmapImage bmp = new BitmapImage(new Uri(@"C:\temp\test.jpg")); //Use the path to your Image 
        DrawingVisual dv = new DrawingVisual();
        DrawingContext dc = dv.RenderOpen();
        dc.DrawImage(bmp, new Rect(100, 100, 300, 300));
            
        dc.DrawText(new FormattedText("Hello World",
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Arial"),
                    30, System.Windows.Media.Brushes.Black),
                    new System.Windows.Point(100, 120));
        dc.Close();
        myGrid.Background = new VisualBrush(dv); 
        this.Content = myGrid;
    }
