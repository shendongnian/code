    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        // if being redirected from another page, remove the search attributes
        // so it doesn't load the Search Grid view
        if (Page.Request.UrlReferrer != Page.Request.Url)
        {
            Session[UNMGeneralConstants.SearchAttributes] = null;
        }
        UserManagementBO userManagementBO = new UserManagementBO();
        dsUserInSites = userManagementBO.GetSitesNameForUser(new Guid(Session[SessionVariables.Ses_UserId].ToString()));
        DataSet dsSearchResults2 = Session[UNMGeneralConstants.SearchAttributes] as DataSet;
        if (dsSearchResults2 != null && dsSearchResults2.Tables.Count != 0)
        {
            gvExistingPatientsSearch.DataSource = dsSearchResults2;
            gvExistingPatientsSearch.DataBind();
        }
        else
        {
            gvExistingPatientsSearch.DataSource = null;
            gvExistingPatientsSearch.DataBind();
        }
    }
