    protected void grdvEventosVendedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList dpdListEstatus = e.Row.FindControl("dpdListEstatus") as DropDownList;
            dpdListEstatus.SelectedValue = DataBinder.Eval(e.Row.DataItem, "FieldName").ToString();
        }
    }
    protected void dpdListEstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //your logic goes here
    }
