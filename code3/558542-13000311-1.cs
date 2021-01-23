    void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            // Check if selected item is editable and act accordingly...
            // Bypass the control's default handling; 
            // otherwise, remove to pass the event to the default control handler.
            e.Handled = true;
        }
    }
