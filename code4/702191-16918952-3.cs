    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            displayImage();
        }
    
        private void displayImage()
        {
            newImage.Width = 900;
            newImage.Height = 700;
    
            BitmapImage testim = new BitmapImage();
            testim.BeginInit();
            testim.UriSource = new Uri("E:\\WpfApplication1\\Images\\test.jpg");
            testim.EndInit();
    
            newImage.Source = testim;
        }
    }
