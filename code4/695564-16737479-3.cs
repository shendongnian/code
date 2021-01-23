    protected void PendingList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime cureExpires;
            var expiresLiteral = e.Row.FindControl("ExpiresLiteral") as Literal;
            var obj = ((DataRowView) e.Row.DataItem)["CureExpires"];
    
            if (obj != null && DateTime.TryParse(obj.ToString(), out cureExpires))
            {
                if (cureExpires < DateTime.Now)
                    expiresLiteral.Text = "Expired";
                else
                    expiresLiteral.Text = cureExpires.ToShortDateString();
            }
            else
            {
                expiresLiteral.Text = "N/A";
            }
        }
    }
