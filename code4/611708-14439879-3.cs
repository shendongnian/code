    DataGridView dgv = null;
    for (int i = 0; i < tabControl1.SelectedTab.Controls.Count; i++)
    {
        if (tabControl1.SelectedTab.Controls[i].GetType() == typeof(DataGridView))
        {
            dgv = (DataGridView)tabControl1.SelectedTab.Controls[i];
        }
    }
