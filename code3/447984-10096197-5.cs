    using System.Windows;
    using System.Windows.Input;
        
    namespace stackoverflow___scope_of_menu_shortcut_key
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void HelpCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = true;
            }
    
            private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                System.Diagnostics.Process.Start("http://www.microsoft.com");
            }
        }
    }
