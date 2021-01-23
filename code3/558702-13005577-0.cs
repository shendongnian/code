    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox ctl = e.Control as ComboBox;
        ctl.Enter -= new EventHandler(ctl_Enter);
        ctl.Enter += new EventHandler(ctl_Enter);
    }
    void ctl_Enter(object sender, EventArgs e)
    {
        (sender as ComboBox).DroppedDown = true;
    }
