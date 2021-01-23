    using System.Windows;
    using System.Windows.Input;
    namespace LeftClickMenu
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
            private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                myContextMenu.IsOpen = true;
            }
            private void Border_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
            {
                e.Handled = true;
            }
        }
    }
