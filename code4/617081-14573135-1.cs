    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void onDragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
            Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);
        }
    }
