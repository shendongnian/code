    public Graph()
    {
        InitializeComponent();
        Plot = new OxyPlot.WindowsForms.Plot();
        Plot.Model = new PlotModel();
        Plot.Dock = DockStyle.Fill;
        this.Controls.Add(Plot);
        Plot.Model.PlotType = PlotType.XY;
        Plot.Model.Background = OxyColor.FromRgb(255, 255, 255);
        Plot.Model.TextColor = OxyColor.FromRgb(0, 0, 0);
       // Create Bar series
         var s1 = new BarSeries { Title = "BarSeries 1", BaseValue = 0.1, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
        s1.Values.Add(25);
        s1.Values.Add(37);
        s1.Values.Add(18);
        s1.Values.Add(40);
        // Add axis
        var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };
        categoryAxis.Labels.Add("Category A");
        categoryAxis.Labels.Add("Category B");
        categoryAxis.Labels.Add("Category C");
        categoryAxis.Labels.Add("Category D");
        // add Series and Axis to plot model
        Plot.Model.Series.Add(s1);
        Plot.Model.Axes.Add(categoryAxis);
        Plot.Model.Axes.Add(new LogarithmicAxis(AxisPosition.Left) { Minimum = 0.1, MinimumPadding = 0, AbsoluteMinimum = 0 });
    }
