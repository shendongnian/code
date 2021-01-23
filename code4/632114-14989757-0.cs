    public UpdatePanelUpdateMode UpdateMode
    {
        get { return this.UpdatePanel1.UpdateMode; }
        set { this.UpdatePanel1.UpdateMode = value; }
    }
    
    public void Update()
    {
        this.UpdatePanel1.Update();
    }
