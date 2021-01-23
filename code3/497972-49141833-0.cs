    public frmMain ( ) {
        InitializeComponent ( );
        pbxMoveIt.BringToFront ( );
        gbx1.AllowDrop = true;
        gbx2.AllowDrop = true;
        lblStatus.Text = "GUI Status: Started";
        gbx1.MouseEnter += gbx_MouseEnter;
        gbx1.MouseLeave += gbx_MouseLeave;
        gbx1.MouseUp += gbx_MouseUp;
        gbx2.MouseEnter += gbx_MouseEnter;
        gbx2.MouseLeave += gbx_MouseLeave;
        gbx2.MouseUp += gbx_MouseUp;
    }
    private void gbx_MouseEnter ( object sender, EventArgs e ) {
        // useful code
        // ...
    }
    private void gbx_MouseLeave ( object sender, EventArgs e ) {
        // useful code
        // ...
    }
    private void gbx_MouseUp ( object sender, EventArgs e ) {
        // useful code
        // ...
    }
