    protected void TBDSPC_Command(object sender, GridViewCommandEventArgs e)
    {
        GridView gv = (GridView)sender;
        switch (e.CommandName)
        {
            case "delete":
                {
                        DataTable test = RetrieveData(0, 0); // this is a function I used to get a datatable
                        test.Rows[0].Delete();
                        test.AcceptChanges();
                        TargetedSpView = test.DefaultView;
                        TBDSPCGrid.DataSource = TargetedSpView;
                        TBDSPCGrid.DataBind();
                }
                break;
    }
    }
