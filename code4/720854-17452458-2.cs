    void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (dgv1.Columns[e.ColumnIndex].Name == "Enabled")
      {
        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgv1.Rows[e.RowIndex].Cells["Enabled"];
        if(!checkCell.Checked)
        {
           DialogResult result = MessageBox.Show(this, "Are you sure you want to Disable this?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
           if (result == DialogResult.No)
           {
              checkCell.Value = checkCell.TrueValue;
           }
    
        }		
      }
    }
