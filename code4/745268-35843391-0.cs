     var temp = ot_approval_grid.DataKeys[GridView.RowIndex].Value;
     //ot_approval_grid is the id of grid view
    foreach (GridViewRow GridView in ot_approval_grid.Rows)
                {
                   CheckBox isapplicable = (CheckBox)GridView.FindControl("chkrow");
                   if (isapplicable != null && isapplicable.Checked)
                   {
                       //var temp = GridView.Cells["OTApplicationID"];
                       var temp = ot_approval_grid.DataKeys[GridView.RowIndex].Value;
                   }
