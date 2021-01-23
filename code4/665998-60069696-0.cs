    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.CausesValidation)
        {
            DisableValidation();    
            this.Close();
        }
    }
