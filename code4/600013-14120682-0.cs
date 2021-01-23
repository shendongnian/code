    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      FillStateByCountry();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
      FillLocationByCountryandState();
    }
    private void FillStateByCountry()
    {
        DataSet dstFillState;
        int CountryId = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
        dstFillState = Tbl_State.FillDDLState(CountryId);
        ddlState.DataSource = dstFillState;
        ddlState.DataTextField = "State";
        ddlState.DataValueField = "Id";
        ddlState.DataBind();
    }
