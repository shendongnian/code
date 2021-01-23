    public partial class CustomMenu : Form
    {
        public CustomMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        protected override void OnLostFocus(EventArgs e)
        {
            this.Close();
            base.OnLostFocus(e);
        }
    }
