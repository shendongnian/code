    this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
    private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
              // Then Enter key was pressed
        }
     }
