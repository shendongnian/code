    protected void gvRecordList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        gvRecordList.EditIndex = e.NewEditIndex;
        gvRecordList.DataSource = yourDataSource;
        gvRecordList.DataBind();
    }
  
    protected void gvRecordList_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvRecordList.EditIndex = -1; // this is waht you need to do to reset your GridView from Edit Mode
        gvRecordList.DataSource = yourDataSource;
        gvRecordList.DataBind();
    }
