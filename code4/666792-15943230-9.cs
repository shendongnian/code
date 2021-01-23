    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataRowView dataRow = ( DataRowView ) e.Item.DataItem;
        string strLangId = dataRow["LangId"].ToString();
        DataTable dtData1 = 
        objAccountTypeBAL.ChkLedgerRelation(Convert.ToInt64(strLangId ), objSession.BranchId);
                        
        if (dtData1.Rows.Count > 0)
        {
            ImageButton img = (ImageButton)item["Delete"].Controls[0];
            img.Visible = false;          
        }
    }
        
         
