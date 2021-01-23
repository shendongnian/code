    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var canvas = new Canvas();
            Content = canvas;
            var element = new DrawingVisualElement();
            canvas.Children.Add(element);
            CompositionTarget.Rendering += (s, e) =>
            {
                using (var dc = element.visual.RenderOpen())
                {
                    dc.DrawRectangle(Brushes.Black, null, new Rect(0, 0, 50, 50));
                }
            };
            this.SourceInitialized += new EventHandler(OnSourceInitialized);
        }
        void OnSourceInitialized(object sender, EventArgs e)
        {
            HwndSource source = (HwndSource)PresentationSource.FromVisual(this);
            source.AddHook(new HwndSourceHook(HandleMessages));
        }
        IntPtr HandleMessages(IntPtr hwnd, int msg,IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0x200)
                Title = Mouse.GetPosition(this).ToString(); // because I did not want to split the lParam into High/Low values for Position information
            return IntPtr.Zero;
        }
    }
