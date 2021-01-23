    // hook up both click events of each control to same handler
    butButton.Click += DoSomethingOnClick;
    lbuButton.Click += DoSomethingOnClick;
    private void DoSomethingOnClick(object sender, EventArgs e)
    {
        ...
    }
