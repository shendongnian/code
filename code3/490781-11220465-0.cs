    protected void YourButton_OnClick(object sender, EventArgs e)
    {
        Page.Validate();
        if(Page.IsValid) // Will be false if any validator is invalid
        {
             // your code here
        }
    }
