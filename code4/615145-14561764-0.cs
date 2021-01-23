    public void Save(bool confirmed)
    {
        if (!confirmed && NeedsConfirmation())
        {
            ShowModalWindow();
            return;
        }
        
        // here perform the operation.
    }
    
    public void ButtonSave_Click(object sender, EventArgs e)
    {
        // this is the button that is normally displayed on the form
        this.Save(false);
    }
    
    public void ButtonConfirm_Click(object sender, EventArgs e)
    {
        // this button is located within the modal dialog - so it is not shown before that.
        this.Save(true);
    }
