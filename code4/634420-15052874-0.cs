    btnOk.Enabled = false;
    txtUsername.KeyDown += new KeyEventHandler(textBox1_KeyDown);
    btnOk.Click += new EventHandler(button1_Click);
    private void KeyDownHandle(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // some processing
            btnOk.Enabled = true;
            this.AcceptButton = btnOk;
            txtPassword.Focus();
        }
    }
