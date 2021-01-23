     public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.RemoveLogicalChild(this.Content);    // since protected method
        }
    }
