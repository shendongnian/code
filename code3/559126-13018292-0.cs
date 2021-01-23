	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private PathFigure _pathFigure = new PathFigure();
		PathFigureCollection _pathCollection = new PathFigureCollection();
		PathSegmentCollection _segments = new PathSegmentCollection();
		private PathGeometry _pathGeometry = new PathGeometry();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_pathFigure.Segments = _segments;
			_pathCollection.Add(_pathFigure);
			_pathGeometry.Figures = _pathCollection;
			myPath.Data = _pathGeometry;
		}
		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				LineSegment segment = new LineSegment();
				segment.Point = e.GetPosition(this);
				_pathFigure.Segments.Add(segment);
			}
		}
		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			_pathFigure.StartPoint = e.GetPosition(this);
		}
	}
