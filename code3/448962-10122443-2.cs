    public UpdatePanelUpdateMode UpdateMode
    {
        get { return this.UpdatePanelListaUsers.UpdateMode; }
        set { this.UpdatePanelListaUsers.UpdateMode = value; }
    }
    public void Update()
    {
        this.UpdatePanelListaUsers.Update();
        //your girdview bind method.
        bindGridView()
    }
