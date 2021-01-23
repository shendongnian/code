    protected void btnTest_Click(object sender, EventArgs e)
            {
                MessageBox msgBox = new MessageBox(this, sender, aPanel);
                msgBox.Show("This is my Caption", "this is my message", MessageBox.Buttons.AbortRetryIgnore, MessageBox.DefaultButton.Button1, MessageBox.MessageBoxIcon.Asterisk);
    
            }
