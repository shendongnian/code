    List<TControl> selectedControls = new List<TControl>();
    private void TControl_Click(object sender, EventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == 0)
            return;
        TControl tc = (TControl)sender;
        if (selectedControls.Contains(tc))
            return; // you can remove control here
        selectedControls.Add(tc);
    }
