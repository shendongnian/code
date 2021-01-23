    public partial class MainWindow : Window
    {
        private BezierSegment segment;
        public MainWindow()
        {
            InitializeComponent();
            segment = new BezierSegment(new Point(100, 0), new Point(200, 300), new Point(300, 100), true);
            var figure = new PathFigure();
            figure.Segments.Add(segment);
            figures.Add(figure);
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            segment.Point2 = e.GetPosition(sender as IInputElement);
        }
    }
