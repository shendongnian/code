    //Form parent
    public frmMenu()
            {
                InitializeComponent();
                pnlHide = panel1;
            }
    
    public static Panel pnlHide= new Panel();
    //Form Child
    private void frmChiled_Resize(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    frmMenu.pnlHide.Hide();
                }
                else
                {
                    frmMenu.pnlHide.Show();
                }
            }
