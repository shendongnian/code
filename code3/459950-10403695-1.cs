    private void PerformUpdate()
    {
        try
        {
            // your update code goes here
            DialogResult = DialogResult.OK; // this is the line that tells your other form to refresh
        }
        catch (Exception ex)
        {
            DialogResult = DialogResult.Abort;
        }
    }
