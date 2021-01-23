    List<int> checkedIDs = new List<int>();
    
    foreach (GridViewRow row in grid1.Rows)
    {
      CheckBox chk = (CheckBox)row.FindControl("chkStatus");
      if (chk.Checked){
       checkedMsgIDs.Add(int.Parse(grid1.DataKeys[row.RowIndex].Value.ToString()));
      }
    }
