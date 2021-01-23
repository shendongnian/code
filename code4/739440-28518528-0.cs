    public virtual bool IsWeb()
    {
        return (System.Web.HttpContext.Current != null);
    }
    public virtual bool IsSessionEnabled()
    {
        return IsWeb() && (System.Web.HttpContext.Current.Session != null)
    }
