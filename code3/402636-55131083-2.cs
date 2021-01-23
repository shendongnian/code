    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PART_Image.Source = RenderVisualService.RenderToPNGImageSource(PART_Canvas);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RenderVisualService.RenderToPNGFile(PART_Canvas, "myawesomeimage.png");
        }
    }
