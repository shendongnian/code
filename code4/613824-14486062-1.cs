     for (int i = 0; i < GridView1.Rows.Count; i++) {
            GridViewRow row = GridView1.Rows[i];  
            if(row.RowType == DataControlRowType.DataRow) {
                CheckBoxList CheckBoxList1= row.FindControl("CheckBoxList1")) as CheckBoxList;                 
               //CheckBoxList CheckBoxList1= row.Cells[cbCellIndex].FindControl("CheckBoxList1")) as CheckBoxList;                 
               int checkedCount = 0;
               foreach (ListItem item in CheckBoxList1.Items) {
                   checkedCount += item.Selected ? 1 : 0;
                }
                if (checkedCount == CheckBoxList1.Items.Count) { 
                    //all checked
                }
                else if (checkedCount == 0)
                {
                   //none checked
                }
           }
      }
