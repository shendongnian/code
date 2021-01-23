    <Canvas Background="Transparent" MouseMove="Canvas_MouseMove">
        <Path Stroke="Blue" StrokeThickness="3">
            <Path.Data>
                <PathGeometry x:Name="geometry"/>
            </Path.Data>
        </Path>
    </Canvas>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var segment = new BezierSegment(new Point(100, 0), new Point(200, 300), new Point(300, 100), true);
            var figure = new PathFigure();
            figure.Segments.Add(segment);
            Figures = new PathFigureCollection();
            Figures.Add(figure);
            geometry.Figures = Figures;
        }
        public PathFigureCollection Figures { get; set; }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var firstSegment = Figures[0].Segments[0] as BezierSegment;
            firstSegment.Point2 = e.GetPosition(sender as IInputElement);
        }
    }
