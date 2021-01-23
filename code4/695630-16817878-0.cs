    // Try this set null to DataSource 
    
    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["entryTab"])
            {
                readBox.DataSource = null;
                reminderBox.DataSource  = null;
            }
        }
