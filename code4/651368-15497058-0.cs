    string cssLocalisation  = string.Format("<link rel=\"stylesheet\" href=\"{0}\" type=\"text/css\" />", ResolveUrl(YourFile));
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        var scriptManager = ScriptManager.GetCurrent(Page);
        if ( ! scriptManager.IsInAsyncPostBack)
        {
             ScriptManager.RegisterClientScriptBlock(this, typeof(YourControl), "YourKey", cssLocalisation, false);
        }
     }
