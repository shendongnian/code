    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            for (int i = 1; i < 50; i++)
                myList.Items.Add(i);
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double offset = (double)myScroll.GetValue(MyScrollViewer.MyOffsetProperty);
            DoubleAnimation goDown = new DoubleAnimation(
                offset,
                offset + 100,
                new Duration(TimeSpan.FromSeconds(2)));
            myScroll.BeginAnimation(MyScrollViewer.MyOffsetProperty, goDown);
        }
    }
