    void PopulateAccountInformation()
    {
        DataAccess da = new DataAccess();
        da.AddParameter("SiteID", SiteID, DataAccess.SQLDataType.SQLInteger, 4);
        SiteHeader = da.runSPDataSet("GetSiteAccountList");
        string content = "<ul>";
        for (int i = 0; i < SiteHeader.Tables[0].Rows.Count; i++)
        {
           content +="<li style=\"text-align: left\" >" + SiteHeader.Tables[0].Rows[i]["Account Number"].ToString() + "</li>";
           
        }
        content += "</ul>";
        this.litContent.Text = content;
    }
