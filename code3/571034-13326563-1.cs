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
                    dc.DrawRectangle(Brushes.Black, null, new Rect(0, 0, 50, 50));
            };
            Mouse.Capture(canvas);
            MouseDown += (s, e) => Mouse.Capture((UIElement)s);
            MouseMove += (s, e) => Title = e.GetPosition(canvas).ToString();
            MouseUp += (s, e) => Mouse.Capture(null);
           
        }
