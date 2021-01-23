        /// <summary>
        /// Default Constructor
        /// </summary>
        RemotedWindowsMediaPlayer rm;
        public FrmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //Call me old fashioned - I like to do this stuff manually.  You can do a drag
            //drop if you like, it won't change the results.
            rm = new RemotedWindowsMediaPlayer();
            rm.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Controls.Add(rm);
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((WMPLib.IWMPPlayer4)rm.GetOcx()).currentMedia.sourceURL);
        }
