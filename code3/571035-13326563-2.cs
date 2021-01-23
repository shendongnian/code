    public MainWindow()
    {
        InitializeComponent();
        var canvas = new Canvas();
        Content = canvas;
        DrawingVisualElement element = new DrawingVisualElement();
        Grid myElement = new Grid();
        canvas.Children.Add(myElement);
        CompositionTarget.Rendering += (s, e) =>
        {
            using (var dc = element.visual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.Black, null, new Rect(100, 0, 50, 50));
            }
            DrawingImage myImage = new DrawingImage(element.visual.Drawing);
            myElement.Height = myImage.Height;
            myElement.Width = myImage.Width;
            myElement.Background = new ImageBrush(myImage);
        };
        MouseMove += (s, e) => Title = e.GetPosition(canvas).ToString();
    }
    
