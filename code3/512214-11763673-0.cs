    gvGrid.DataSource = eCustomerMgr.GetCustHistory(oCust);
    gvGrid.DataBind();  
    if (gvGrid.Columns.Count > 0)
    {
        gvGrid.Columns.RemoveAt(0);
    }
