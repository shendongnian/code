    private void form1_load(object sender, EventArg e)
    {
         for (int i = 0; i < gridView1.Rows.Count; ++i)
         {
             DataGridViewComboBoxCell cell = gridView1.Rows[i].Cells[5] as DataGridViewComboBoxCell;
             if (gridView1.Rows[i].Cells[1].Value.ToString() == "one")
             {
                 cell.Items.Clear();
                 cell.Items.Add("one");
                 cell.Items.Add("two");
                 cell.Items.Add("three");
             }
         }
    }
