    public partial class MainWindow : Window
        {
            Line newLine;
            Point start;
            Point end;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DrawCanvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
        }
        private void DrawCanvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }
        private void DrawCanvas_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            
            newLine = new Line();
            newLine.Stroke = SystemColors.WindowFrameBrush;
            newLine.X1 = start.X;
            newLine.Y1 = start.Y;
            newLine.X2 = end.X;
            newLine.Y2 = end.Y;
            DrawCanvas.Children.Add(newLine);
        }
    }
