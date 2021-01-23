    private void gridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
         DataGridViewComboBoxCell cell = gridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
         if (gridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "one")
          {
              cell.Items.Add("one");
              cell.Items.Add("two");
              cell.Items.Add("three");
          }
    }
