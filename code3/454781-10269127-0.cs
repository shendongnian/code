    public frmMain()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(MMForm);
        }
    //You don't need to put anything in form load
        private void frmMain_Load(object sender, EventArgs e)
        {
        }
    
    //This is fine
        private void MMForm(object sender, KeyPressEventArgs e)
        {
            Keys KP; KP = (Keys)sender;
            if (KP == Keys.Escape) { frm2 fM2 = new frm2(); fM2.Show(); }
        }
