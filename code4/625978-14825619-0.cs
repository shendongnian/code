    if (e.KeyCode == Keys.Del && e.Shift)
    {
       if (dataGridView1.SelectedRows.Count > 0)
       {
          //Do Stuff
       }
       e.Handled = true;
    }
