    namespace GridView
    {
        public partial class MainWindow
        {
            private GridSet<byte> _grids;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Open_OnClick(object sender, RoutedEventArgs e)
            {
                var openDialog = new OpenFileDialog();
                if (openDialog.ShowDialog().Value)
                {
                    //Populate _grids with data
                    tbDisplay.Text = "foo";
                }
            }
        }
    }
