    public partial class PopupWin : Window
    {
        public PopupWin()
        {
            InitializeComponent();
        }
        private UserControl control;
        public PopupWin(UserControl control)
            : this()
        {
            this.control = control;
            this.mainPanel.Children.Add(this.control);
        }
    }
