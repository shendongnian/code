     public bool IsRefreshed
        {
            get
            {
                if (Convert.ToString(Session["RefreshTimeStamp"]) == Convert.ToString(ViewState["RefreshTimeStamp"]))
                {
                    Session["RefreshTimeStamp"] = HttpContext.Current.Server.UrlDecode(System.DateTime.Now.ToString());
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ViewState["RefreshTimeStamp"] = Session["RefreshTimeStamp"];
        }
