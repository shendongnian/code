    public FrmZigndSC()
    {
           InitializeComponent();
           this.Focus();
           
           //Subscribe to event
           this.KeyPress += new KeyPressEventHandler(FrmZigndSC_KeyPress);
    }
    private void FrmZigndSC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
            keyPressed = e.KeyChar;
            LblResult.Text = Convert.ToString(keyPressed);
            // Indicate the event is handled.
            e.Handled = true;
    }
