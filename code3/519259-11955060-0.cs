    private void dataGridView1_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox cb = e.Control as ComboBox;
        if (cb != null)
        {
            // first remove event handler to keep from attaching multiple:
            cb.SelectedIndexChanged -= new
    		EventHandler(cb_SelectedIndexChanged);
    
            // now attach the event handler
            cb.SelectedIndexChanged += new 
    		EventHandler(cb_SelectedIndexChanged);
        }
    }
    
    void cb_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Selected index changed");
    }
