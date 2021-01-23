    private void dgvComp_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
       if (dgvComp.Rows[dgvComp.CurrentRow.Index].Cells["EmplId"].ToString() != "")
       {
          if (dgvComp.Columns[e.ColumnIndex].Name == "EmplId")
          {
             {
                DataTable dt = new DataTable();
    
                string auto = dgvComp.Rows[e.RowIndex].Cells["EmplId"].EditedFormattedValue.ToString();
                dt = dataAcc.rtrvData("empl_Name,empl_Id,desg_Name", "dbo.Empldmgrphcs INNER JOIN  dbo.Designation ON dbo.Empldmgrphcs.desg_Id = dbo.Designation.desg_Id ", "empl_EmpId='" + auto + "'");
      
                if(dt.Rows.Count > 0)
                {
                   dgvComp.Rows[e.RowIndex].Cells["dgvname"].Value = dt.Rows[0][0].ToString();
                   dgvComp.Rows[e.RowIndex].Cells["empID"].Value = dt.Rows[0][1].ToString();
                   dgvComp.Rows[e.RowIndex].Cells["dgvdesi"].Value = dt.Rows[0][2].ToString();
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Validation Fail");
                }
             }
          }
       }
    }
