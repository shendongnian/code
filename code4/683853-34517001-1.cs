    protected override void OnPreRender(EventArgs e)
    {
        // find RadMenu first
        RadMenu rm = (RadMenu)this.Master.FindControl("MenuMaster");
        if (rm != null)
        {
            // find that menu item inside RadMenu
            RadMenuItem rmi = (RadMenuItem)rm.FindItemByValue("WorkspaceMenuItems");
            if (rmi != null)
            {
                // find that button inside that Menitem
                Button btn = (Button)rmi.FindControl("ButtonViewReports");
                if (btn != null)
                {
                    // make it visible
                    btn.Visible = true;
                }
            }
        }
        base.OnPreRender(e);
    }
