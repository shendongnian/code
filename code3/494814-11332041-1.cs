    public partial class MainWindow : Window
    {
        public TestWindow MyTestWindow;
        public MainWindow()
        {
            InitializeComponent();
            MyTestWindow = new TestWindow();
            MyTestWindow.Show();
        
            MyTestWindow.LocationChanged += new EventHandler(WinLocationChanged);
            MyTestWindow.SizeChanged += new SizeChangedEventHandler    (   WinSizeChanged);
            this.LocationChanged += new EventHandler(WinLocationChanged);
            this.SizeChanged += new SizeChangedEventHandler(WinSizeChanged);
        }
        void WinSizeChanged(object sender,  SizeChangedEventArgs e)  {
             UpdateLine();         }
        void WinLocationChanged(object sender, EventArgs e)        {            
             UpdateLine();         }
        void UpdateLine()
        {
            // 1. get Window's center in in this window coordinates
            double CX_sc =0.0, CY_sc = 0.0;
              GetWindowCoordinatesInCurrentWindow(MyTestWindow, ref CX_sc, ref CY_sc);
            // 2. Get Center of target Control coordinates in this window coordinates
            Point CenterButtonPoint = MyButton.TransformToAncestor(this).Transform(new Point(MyButton.ActualWidth / 2.0, MyButton.ActualHeight / 2.0));
            //3. Change line's coord.
            MyLine.X1 = CX_sc;
            MyLine.Y1 = CY_sc;
            MyLine.X2 = CenterButtonPoint.X;
            MyLine.Y2 = CenterButtonPoint.Y;
        }
        void GetWindowCoordinatesInCurrentWindow(Window ChildWindow, ref double X, ref double Y)
        {
            Point CenterOfChildWindow = ChildWindow.PointToScreen(new Point((ChildWindow.ActualWidth / 2)
                                                        , ChildWindow.ActualHeight/2));
            Point UpperLeftOfCurrentWindow = this.PointToScreen(new Point(0, 0));
              PresentationSource source = PresentationSource.FromVisual(this);
            double dpiX = ( source.CompositionTarget.TransformToDevice.M11);
            double dpiY = (source.CompositionTarget.TransformToDevice.M22);
            X = (( CenterOfChildWindow.X -UpperLeftOfCurrentWindow.X ) /dpiX);
            Y = ( (CenterOfChildWindow.Y-UpperLeftOfCurrentWindow.Y   ) / dpiY );
        }
    }
