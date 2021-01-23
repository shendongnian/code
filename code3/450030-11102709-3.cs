    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // img is of Image type for example
                img.Source = Emfutilities.ToBitmapSource("SampleMetafile.emf");
            }
        }
    
    }
