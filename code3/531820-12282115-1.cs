     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Label l = new Label();
           
            canBackArea.Children.Add(l);
            l.Visibility = System.Windows.Visibility.Visible;
            l.Content = "Hello";
            Canvas.SetLeft(l, 20);
            Canvas.SetTop(l, 20);
        }
