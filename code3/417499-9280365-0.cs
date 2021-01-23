    private int Counter
    {
        get { return ((int?)this.ViewState["Counter"]).GetValueOrDefault(); }
        set { this.ViewState["Counter"] = value; }
    }
