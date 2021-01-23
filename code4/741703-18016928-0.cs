    public frmSTOverScrollText()
    {
        InitializeComponent();
        txtInput.MouseWheel += new MouseEventHandler(txtInput_MouseWheel);
    }
    
    void txtInput_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta < 0)
        {
            if (vsInput.Value + vsInput.LargeChange <= vsInput.Maximum)
                vsInput.Value += vsInput.LargeChange;
        }
        else if (vsInput.Value - vsInput.LargeChange >= vsInput.Minimum)
            vsInput.Value -= vsInput.LargeChange;
    }
