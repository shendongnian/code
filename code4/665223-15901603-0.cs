    int i=0;
    ds = new DataSet();
    ds = db.getDetailRecords(Convert.ToInt32(txtBillNo.Text));
    //add this
    grdData.DataSource = ds.Tables[0];
    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
         grdData.Rows[i].Cells[0].Value = i;
         //You don't need to set the other properties, they were binded when you put the DataSource in there
         grdData.Rows[i].Cells[5].Value = Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"]);                        
    }
