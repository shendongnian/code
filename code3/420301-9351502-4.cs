    [Bindable(true)]
    [DefaultValue(LabelColor.None)]
    [Category("Appearance")]
    public LabelColor TextColor
    {
        get
        {
            EnsureChildControls();
            return (ViewState["TextColor"] != null) ?
                (LabelColor)Enum.Parse(typeof(LabelColor), ViewState["TextColor"].ToString()) :
                LabelColor.None;
        }
        set
        {
            EnsureChildControls();
            ViewState["TextColor"] = value;
        }
    }
