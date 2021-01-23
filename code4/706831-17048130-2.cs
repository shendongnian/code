    string dgvName = "data_grid_view_name";
    if (tabControl1.SelectedTab != null)
    {
        var nestedTabControl = (from TC in tabControl1.SelectedTab.Controls.OfType<TabControl>() select TC).FirstOrDefault();
        if (nestedTabControl != null && nestedTabControl.SelectedTab != null)
        {
            Control[] matches = nestedTabControl.SelectedTab.Controls.Find(dgvName, true);
            if (matches.Length > 0 && matches[0] is DataGridView)
            {
                DataGridView dgv = (DataGridView)matches[0];
                // ... do something with "dgv" ...
            }
        }
    }
