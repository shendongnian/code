    private bool Visible
    {
        get
        {
            return (bool) base.ShadowProperties["Visible"];
        }
        set
        {
            base.ShadowProperties["Visible"] = value;
        }
    }
