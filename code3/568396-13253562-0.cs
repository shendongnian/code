    public Form1()
    {
        InitializeComponent();
        txtHomePhone.KeyPress += new KeyPressEventHandler(txtHomePhone_KeyPress);
    }
    private void txtHomePhone_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '') //The  character represents a backspace
        {
            e.Handled = false; //Do not reject the input
        }
        else
        {
            e.Handled = true; //Reject the input
        }
    }
