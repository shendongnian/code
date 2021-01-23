    public partial class ItemRecorUserControl : UserControl
    {
        public event EventHandler<EventArgs> ActionButtonClicked;
        public void OnActionButtonClicked(object sender, EventArgs e)
        {
            if (this.ActionButtonClicked != null)
                this.ActionButtonClicked(sender, e);
        }
        public ItemRecorUserControl()
        {
            InitializeComponent();
        }
        public ItemRecorUserControl(ItemRecord item) : this()
        {
            // fill item data here to controls
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            this.OnActionButtonClicked(sender, e);
        }
    }
