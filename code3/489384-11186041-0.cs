    private void center_Load(object sender, System.EventArgs e)
    {
    // Position the Form on The screen taking in account
    the resolution
    //
    Rectangle screenRect = Screen.GetBounds(Bounds);
    // get the Screen Boundy
    ClientSize = new Size((int)(screenRect.Width/2),
    
    (int)(screenRect.Height/2)); // set the size of the form
    Location = new
    Point(screenRect.Width/2-ClientSize.Width/2,
    
    screenRect.Height/2-ClientSize.Height/2); // Center the Location of
    the form.
    }
