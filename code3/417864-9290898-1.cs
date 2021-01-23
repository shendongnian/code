    using System.Windows;
    namespace SO
    {
        public partial class MainWindow :Window
        {
            public MainWindow( )
            {
                InitializeComponent( );
            }
            private void Move_Click( object sender, RoutedEventArgs e )
            {
                this.topBorder.Child = null;
                this.bottomBorder.Child = this.ctrl;
            }
        }
    }
