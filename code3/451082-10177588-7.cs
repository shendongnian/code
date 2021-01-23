     public Window1()
        {
            InitializeComponent();
            //
            const int N = 100;
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            
            DateTimeAxis dtAxis = new DateTimeAxis();
            _plotter.HorizontalAxis = dtAxis;
            
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {   //generate some random data
                x.Add(dtAxis.ConvertToDouble(DateTime.Now.AddDays(i)));
                y.Add(rand.Next(N));
            }
            EnumerableDataSource<double> gX = new EnumerableDataSource<double>(x);
            EnumerableDataSource<double> gY = new EnumerableDataSource<double>(y);
            _MarkerGraph.DataSource = new CompositeDataSource(gX,gY);
            
            //no scaling - identity mapping
            gX.XMapping = xx => xx;
            gY.YMapping = yy => yy;
            CirclePointMarker mkr = new CirclePointMarker();
            mkr.Fill = new SolidColorBrush(Colors.Red);
            mkr.Pen = new Pen(new SolidColorBrush(Colors.Black),2.0);
            _MarkerGraph.Marker = mkr;
        }
