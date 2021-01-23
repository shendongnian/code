    public override void VerifyRenderingInServerForm(Control control)
    {
        if (!SkipVerifyRenderingInServerForm)
        {
            base.VerifyRenderingInServerForm(control);
        }
    }
    public bool SkipVerifyRenderingInServerForm
    {
        get
        {
            object o = HttpContext.Current.Items["SkipVerifyRenderingInServerForm"];
            return (o == null) ? false : (bool) o;
        }
        set
        {
            HttpContext.Current.Items["SkipVerifyRenderingInServerForm"] = value;
        }
    }
