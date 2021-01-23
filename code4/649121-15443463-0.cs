    // class A
    public void AddMyControl(Control c)
    {
        mydiv.Controls.Add(c); // mydiv is defined in the designer
    }
    // somewhere else - maybe in the page?
    theControl.AddMyControl(Page.LoadControl(thePath));
