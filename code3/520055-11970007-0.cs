     public partial class MainWindow : Window
    {
        public delegate void MenuClickedDelegate(); 
        public MainWindow()
        {
           InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           YourDialog yourDialog = new YourForm();
           yourDialog .MenuClickCallback = new MenuClickedDelegate(this.DoSomething);
           yourDialog .ShowDialog();
        }
        private void DoSomething()
        {
        }
    }
