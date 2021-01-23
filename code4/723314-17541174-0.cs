    protected void rptrdepartment_databound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            Authorization assign_auth = new Authorization();
            int Roleid = Convert.ToInt32(Session["Roleid"]);
            assign_auth.ChangeControlStatus(Page.Controls, Roleid, "Approval Path", e);
        }
    }
