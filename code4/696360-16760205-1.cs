    namespace WpfApplication2
    {
        using System.Windows;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ViewModel viewModel = new ViewModel();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void SettingsWindowButton_OnClick(object sender, RoutedEventArgs e)
            {
                var settingsWindow = new SettingsWindow();
                settingsWindow.DataContext = viewModel;
                settingsWindow.Show();
            }
    
            private void BoundWindowButton_OnClick(object sender, RoutedEventArgs e)
            {
                var boundWindow = new BoundWindow();
                boundWindow.DataContext = viewModel;
                boundWindow.Show();
            }
        }
    }
