    foreach (GridViewRow gvr in GridView1.Rows)
    {
     tbCell = new TableCell();
     cbGV = new CheckBox();
     cdGV.id="cbGV";
     tbCell.Controls.Add(cbGV);
     gvr.Cells.Add(tbCell);
    }
    foreach (GridViewRow getRowItems in GridView1.Rows)
    {
      chkBox = (CheckBox)(getRowItems.Cells[0].FindControl("cbGV"));
      if(chkBox.Checked == false) 
      {
      chkBox.Checked = true;
      }
  }
