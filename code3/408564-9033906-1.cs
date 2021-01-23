    public bool DisableFlag { get; set; }
 
    public void MyKeyEventHandler(object sender, EventArgs e)
    {
        if (DisableFlag)
        {
            return;
        }
        // Do stuff
    }
