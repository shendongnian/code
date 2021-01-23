    private void ConfigureAcceptButton(object sender, EventArgs e)
    {
    try
    {
    acceptButton.Enabled = (ConnectionProperties != null) ? ConnectionProperties.IsComplete : false;
    }
    catch
    {
    acceptButton.Enabled = true;
    }
    }
