    private void tabControl_SelectedIndexChanged(...)
    {
        int index = tabControl.SelectedIndex;
        if (index == 0) HideTextBoxes(false);
        else HideTextBoxes(true);
    }
    
    private void HideTextBoxes(bool someSelector)
    {
        txtTripNo.Visible = someSelector;
        txtTripNo2.Visible = !someSelector;
    }
