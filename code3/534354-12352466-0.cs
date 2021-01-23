    private void Page_Load (object sender, System.EventArgs e)
    {
        // ... previous code ...
        // Add the following code:
        if (Context.User.IsInRole("Admin"))
        {
            myLink.Visible = true;
        }
        else
        {
            myLink.Visible = false;
        }
        // ... following code ...
    }
