        protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var mailid = DataBinder.Eval(e.Row.DataItem, "mailid");
                e.Row.Attributes["onClick"] = "getMailDetail(" + DataBinder.Eval(e.Row.DataItem, "mailid") + ")";
                e.Row.Attributes["id"] = mailid.ToString();
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus.Text == "unread")
                {
                    e.Row.Font.Bold = true;
                }
            }
        }
