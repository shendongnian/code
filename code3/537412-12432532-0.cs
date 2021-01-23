    void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as ComboBox;
        if (comboBox != null)
        {
            // remove any handler we may have added previously
            comboBox.SelectionChangeCommitted -= new EventHandler(comboBox_SelectionChangeCommitted);
            // add handler
            comboBox.SelectionChangeCommitted += new EventHandler(comboBox_SelectionChangeCommitted);
        }
    }
    void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
        // Allow current dispatch to complete (combo-box submitting its value)
        //  then EndEdit to commit the change to the row
        dgv.BeginInvoke(new Action(() => dgv.EndEdit()));
    }
