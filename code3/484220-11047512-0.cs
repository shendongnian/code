    Form1.FormClosing += new FormClosingEventHandler(Form1_Closing);
    ....
    private void Form1_FormClosing(Object sender, FormClosingEventArgs e) 
    {
        DialogResult d = MessageBox.Show("Confirm closing", "AppTitle", MessageBoxButtons.YesNo );
        if(d == DialogResult.No)
            e.Cancel = true;
    }
