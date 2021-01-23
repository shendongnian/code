    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(e.CloseReason == CloseReason.UserClosing)
        {
             //close forms
             Application.Exit();
        }
    }
