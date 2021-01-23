    [Category("Behavior")]
    [DisplayName("ContainerControl")]
    [Description("It indicates container control high lighter is bound to. It should be set to parent form.")]
    //[DefaultValue("")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false), ReadOnly(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control ContainerControl
    {
        get { return hltMain.ContainerControl; }
        private set { hltMain.ContainerControl = this; }
    }
