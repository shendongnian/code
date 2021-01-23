    protected void SubmitWithValidation(object sender, EventArgs e)
    {
        if (ValidateMyData())
        {
                SubmitData(sender, e);
        }
        else
        {
            mySecondButton.Visible = true;
            myFirstButton.Visible = false;
        }
    }
    private bool ValidateMyData()
    {
        // Validate stuff
        return isValid;
    }
    private void SubmitData(object sender, EventArgs eventArgs)
    {
        // Logic to submit your data here
    }
