    protected void Pre_Render(object sender, EventArgs e)
    {
        //repositioning token
        this.HdfSyncToken.Value = SynchronizerToken.CurrentToken();
    
        //Refresh GridView
        this.GrvRecords.DataSource = this.Records;
        this.GrvRecords.DataBind();
    }
    protected void BtnInsertST_Click(object sender, EventArgs e)
    {
        //Abort second execution for the same value of the token
        if (!SynchronizerToken.IsCurrentTokenRenew(this.HdfSyncToken.Value))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script type='text/javascript'>alert('Request has already been answered!');</script>");
        }
        //Insert Record (token validation OK)
        else
        {
            this.InsertRecord();
        }
    }
