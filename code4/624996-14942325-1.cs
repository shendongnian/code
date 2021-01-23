    protected void gv_inbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "sign")
        {
            Session["TransYear"] = int.Parse(((HiddenField)gv_inbox.Rows[index].Cells[1].FindControl("HDN_TransYear")).Value);
            Session["MailNumber"] = int.Parse(((HiddenField)gv_inbox.Rows[index].Cells[1].FindControl("HDN_MailNumber")).Value);
            Utilities.RedirectToNewWindow(gv_inbox, "Signature.aspx");
        }
    }
