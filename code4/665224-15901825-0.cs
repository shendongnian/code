    int i=0;
    ds = new DataSet();
    ds = db.getDetailRecords(Convert.ToInt32(txtBillNo.Text));
    
    grdData.Rows.Clear()
    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
         grdData.Rows.Add(); /// For add a Row. then does not show index out of range error
         grdData.Rows[i].Cells[0].Value = i;
         grdData.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i]["Description"].ToString();
         grdData.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i]["HSNCode"].ToString();
         grdData.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i]["Qty"].ToString();
         grdData.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i]["Rate"].ToString();
         grdData.Rows[i].Cells[5].Value = Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"]);                        
    }
