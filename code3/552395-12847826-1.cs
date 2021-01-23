    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void sldChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            red = sldRed.Value;
            green = sldGreen.Value;
            blue = sldBlue.Value;
            changeColors(red, green, blue);
        }
    
        void changeColors(double red, double green, double blue)
        {
    
        }
    }
