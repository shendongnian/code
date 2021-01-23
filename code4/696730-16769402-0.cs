    // In form load or form initialization
    cb1.SelectionChangeCommitted += ComboBoxSelectionChangeCommitted;
    
    // Event
    private void ComboBoxSelectionChangeCommitted(object sender, EventArgs e)
    {
        cb2.Visible = cb1.SelectedItem != null && cb1.Text == "3";
    }
