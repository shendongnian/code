    //Delete
    protected void gvPartNumber_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindGridView();
        DataSet dsgvPartNumber = new DataSet();
        dsgvPartNumber.ReadXml(Server.MapPath("~/xml/storeUserInfo.xml"));
        dsgvPartNumber.Tables["partNumbers"].Rows[gvPartNumber.Rows[e.RowIndex].DataItemIndex].Delete();
        dsgvPartNumber.WriteXml(Server.MapPath("~/xml/storeUserInfo.xml"));
        BindGridView();
    
    }
    
    //Update GridView
    protected void gvPartNumber_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index = gvPartNumber.Rows[e.RowIndex].DataItemIndex;
        string partId = ((TextBox)gvPartNumber.Rows[e.RowIndex].FindControl("txtPartID")).Text;
        string partNumber = ((TextBox)gvPartNumber.Rows[e.RowIndex].FindControl("txtPartNumber")).Text;
        gvPartNumber.EditIndex = -1;
        BindGridView();
    
        DataSet dsgvPartNumber = new DataSet();
        dsgvPartNumber.ReadXml(Server.MapPath("~/xml/storeUserInfo.xml"));
        dsgvPartNumber.Tables["partNumbers"].Rows[index]["partid"] = partId;
        dsgvPartNumber.Tables["partNumbers"].Rows[index]["partnumber"] = partNumber;
        dsgvPartNumber.WriteXml(Server.MapPath("~/xml/storeUserInfo.xml"));
        BindGridView();
    
    }
    
    //Insert New Row
    protected void gvPartNumber_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    
        if (e.CommandName == "insertXMLData")
        {
            string partid = ((TextBox)gvPartNumber.FooterRow.FindControl("txtPartIDInsert")).Text;
            string partnumber = ((TextBox)gvPartNumber.FooterRow.FindControl("txtPartNumberInsert")).Text;
            BindGridView();
            DataTable dtXMLInsert = (DataTable)gvPartNumber.DataSource;
    
            DataSet dsgvPartNumber = new DataSet();
            dsgvPartNumber.ReadXml(Server.MapPath("~/xml/storeUserInfo.xml"));
            DataRow drInsert = dsgvPartNumber.Tables["partNumbers"].NewRow(); 
            drInsert["partid"] = partid;
            drInsert["partnumber"] = partnumber;
            dsgvPartNumber.Tables["partNumbers"].Rows.Add(drInsert);
            dsgvPartNumber.WriteXml(Server.MapPath("~/xml/storeUserInfo.xml"));
            BindGridView();
    
        }
    }
