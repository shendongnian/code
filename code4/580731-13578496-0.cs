    private void OnButtonAClicked(object sender, EventArgs e)
    {
        ButtonA.Enabled = false;
        ButtonA.Click -= OnButtonAClicked;
        ButtonB.Click += OnButtonBClicked;
        ButtonB.Enabled = true;
    }
    private void OnButtonBClicked(object sender, EventArgs e)
    {
        ButtonB.Enabled = false;
        ButtonB.Click -= OnButtonBClicked;
        // Do something truly special here
        ButtonA.Click += OnButtonAClicked;
        ButtonA.Enabled = true;
    }
