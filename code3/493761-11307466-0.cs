    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        object someArgsInterestingForTheMethod = new object();
    
        e.Cancel = !((IManagedForm)this).CanIBeClosed(someArgsInterestingForTheMethod);
    }
    
    // Ask the ChildForm it is done. If not the user should not leave the application.
    public bool CanIBeClosed(object someParams)
    {
        bool isOKforClosing = true;
    
        var cf = this.Controls["ChildForm"] as IManagedForm;
    
        if (cf != null)
        {
            isOKforClosing = cf.CanIBeClosed(someParams);
            if (!isOKforClosing)
            {
                MessageBox.Show("ChildForm does not allow me to close.", "Form1", MessageBoxButtons.OK);
            }
        }
        return isOKforClosing;
    }
