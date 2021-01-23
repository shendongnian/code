    private Canvas canvas;
    
    public MainWindow()
    {
        InitializeComponent();
    
        chart.Loaded += this.OnChartLoaded;
    }
    
    private void OnChartLoaded(object sender, RoutedEventArgs e)
    {
        var chartArea = (Panel)chart.GetType().GetProperty("ChartArea", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(chart, null);
        
        // create a canvas to which all text blocks will be added
        this.canvas = new Canvas();
        chartArea.Children.Add(this.canvas);
    }
    public void AddAllLineLabels() 
    {
        // add a red label
        double value = 15;
        var text = new TextBlock() { Text = value.ToString(), Foreground = Brushes.Red };
        AddTextToCanvas(canvas, text, value);
    
        // add a green label
        value = 19;
        text = new TextBlock() { Text = value.ToString(), Foreground = Brushes.Green };
        AddTextToCanvas(canvas, text, value);
    }
    private void AddTextToCanvas(Canvas canvas, TextBlock text, double value)
    {
        var valuesAxis = chart.ActualAxes.OfType<LinearAxis>().FirstOrDefault(ax => ax.Orientation == AxisOrientation.Y);
    
        var min = valuesAxis.ActualMinimum.Value;
        var max = valuesAxis.ActualMaximum.Value;
    
        var maxPixels = valuesAxis.ActualHeight;
        var valuePixels = (value - min) / (max - min) * maxPixels; // from the bottom edge to the value in pixels
    
        Canvas.SetRight(text, 5); // 5 is a padding from the right edge, you can use any number
        Canvas.SetBottom(text, valuePixels);
        canvas.Children.Add(text);
    }
