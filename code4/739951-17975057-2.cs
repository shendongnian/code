    namespace TreeViewExample
    {
        using System.Windows;
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                DataContext = new MainWindowViewModel();
                InitializeComponent();
            }
        }
    }
