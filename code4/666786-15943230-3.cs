    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridDataItem item = (GridDataItem)e.Item;
        string strLangId = item.GetDataKeyValue("LangId").ToString();
        DataTable dtData1 = objAccountTypeBAL.ChkLedgerRelation(Convert.ToInt64(strLedgerId), objSession.BranchId);
                    
        if (dtData1.Rows.Count > 0)
        {
            ImageButton img = (ImageButton)item["Delete"].Controls[0];
            img.Visible = false;          
        }
    }
    
     
