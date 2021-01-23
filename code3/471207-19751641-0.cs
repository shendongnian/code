    //public area
     int selectedID,rowIndex, scrollIndex;
     bool IsSelectedRow;
        
     private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          if (e.RowIndex < 0)
              return;
          selectedID = (int)DataGridView1.SelectedRows[0].Cells[0].Value;
          scrollIndex = DataGridView1.FirstDisplayedScrollingRowIndex;
          IsSelectedRow = true;
        }
        
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
                {
                    if (IsSelectedRow)
                    {
                        foreach (DataGridViewRow row in DataGridView1.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(selectedID.ToString()))
                            {
                                rowIndex = row.Index;
                                break;
                            }
                        }
                        DataGridView1.Rows[rowIndex].Selected = true;
                    }           
                }
