    public partial class PasswordTextBox : TextBox
    {
        private const int EM_SHOWBALLOONTIP = 0x1503;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == EM_SHOWBALLOONTIP)
            {
                m.Result = (IntPtr)0;
                return;
            }
            base.WndProc(ref m);
        }
        public PasswordTextBox()
        {
            InitializeComponent();
        }
    }
