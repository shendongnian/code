        public partial class WMForm : Form,IMessageFilter
    {
        public WMForm()
        {
            InitializeComponent();
        }
 
        private void WMForm_Load(object sender, EventArgs e)
        {
            this.MyWindowsMediaPlayer.URL = @"YourFilePath/Url";
            Application.AddMessageFilter(this);
        }
 
        private void WMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }
 
        #region IMessageFilter
        private const UInt32 WM_KEYDOWN = 0x0100;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
                if (keyCode == Keys.Escape)
                {
                    this.MyWindowsMediaPlayer.fullScreen = false;
                }
                return true;
            }
            return false;
        }
        #endregion
    }
