    protected void btnSendUser_OnClick(object sender, EventArgs e)
    {
        string Loginfo = txtUserAdd.Text;
        string LoginInfo = txtUserAdd.Text;
        PrincipalContext insPrincipalContext = new PrincipalContext(ContextType.Domain, "x.com", "amsndruser", "XXX");
        UserPrincipal insUserPrincipal = UserPrincipal.FindByIdentity(insPrincipalContext, LoginInfo);
        if (insUserPrincipal == null)
        {
            lblError.Visible = true;
        }
        else
        {
            lblsuccess.Visible = true;
            lblUser.Visible = true;
            lblUser.Text = txtUserAdd.Text;
        }
    }
