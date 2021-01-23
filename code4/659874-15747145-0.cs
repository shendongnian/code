    protected void DataListStatus_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item || 
          e.Item.ItemType == ListItemType.AlternatingItem)
       {
        da.SelectCommand = new SqlCommand("SELECT * FROM Comment WHERE Thread_ID='" +      ((HiddenField)e.Item.FindControl("HFieldThreadID")).Value + "'", con);
        con.Open();
        da.Fill(ds, "cmts");
        con.Close();
        var dataList = (DataList)e.Item.FindControl("DataListCmt");
        dataList.DataSource = ds.Tables["cmts"];
        dataList.DataBind();
       }
    }
