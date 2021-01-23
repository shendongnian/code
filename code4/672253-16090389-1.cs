    public partial class TextBoxUsingDefaultContextMenu : TextBox
    {
        public TextBoxUsingDefaultContextMenu()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_CONTEXTMENU = 0x007B;
            const int WM_MENUCOMMAND = 0x0126;
            const int WM_COMMAND = 0x0111;
            switch (m.Msg)
            {
                case WM_CONTEXTMENU:
                    MessageBox.Show("Opening Context Menu");
                    break;
                case WM_MENUCOMMAND:
                    MessageBox.Show("WM Menu Command Event fired");
                    break;
                case WM_COMMAND:
                    MessageBox.Show("WM Command Event fired");
                    break;
            }
            base.WndProc(ref m);
        }
        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }
    }
