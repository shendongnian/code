    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        if (Page.IsPostBack)
        {
            Response.Write("Hidden value :" + HiddenField1.Value);
        }
    }
