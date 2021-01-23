    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            // register for the other windows closing
            WindowManager.ClosingWindows += WindowManager_ClosingWindows;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseWindows();
        }
        void WindowManager_ClosingWindows(object sender, EventArgs e)
        {
            // when other windows close, close this as well
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
         
            // when closed remove eventhandler
            WindowManager.ClosingWindows -= WindowManager_ClosingWindows;
        }
    }
