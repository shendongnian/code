        public partial class NewFullScreenWindow : Window
        {
            public NewFullScreenWindow()
            {
                InitializeComponent();
                KeyDown += HandleKeyDown;
            }
    
            private void HandleKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Escape || e.Key == Key.F11)
                {
                    Close();
                }
            }
        }
