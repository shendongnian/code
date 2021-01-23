        public Graph()
        {
            InitializeComponent();
    
            Plot = new OxyPlot.WindowsForms.Plot();
            Plot.Model = new PlotModel();
            Plot.Dock = DockStyle.Fill;
            this.Controls.Add(Plot);
            Plot.Model.PlotType = PlotType.XY;
            Plot.Model.Background = OxyColor.FromRGB(255, 255, 255);
            Plot.Model.TextColor = OxyColor.FromRGB(0, 0, 0);
            // Create Line series
            var s1 = new LineSeries { Title = "LineSeries", StrokeThickness = 1 };
            s1.Points.Add(new DataPoint(2,7));
            s1.Points.Add(new DataPoint(7, 9));
            s1.Points.Add(new DataPoint(9, 4));
            // add Series and Axis to plot model
            Plot.Model.Series.Add(s1);
            Plot.Model.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0.0, 10.0));
            Plot.Model.Axes.Add(new LinearAxis(AxisPosition.Left, 0.0, 10.0));
        }
