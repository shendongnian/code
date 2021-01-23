    private void    Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(MessageBox.Show("Are you sure that you want to exit", 
                            MessageBoxButtons.YesNo, 
                            MessageBoxIcon.question) == DialogResult.No)
        {
            e.Cancel=true;
        }
    }
    //in formclose event
    private void Form1_FormClosed(object sender,FormClosedEventArgs e)
    {
        Application.Exit();
    }
