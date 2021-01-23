    public partial class MainWindow : Window
      {
        private Window1 window2;
    
        public MainWindow()
        {
          InitializeComponent();
          this.window2 = new Window1();
          
          this.window2.Show();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          this.window2.Visibility = System.Windows.Visibility.Hidden;
        }
      }
