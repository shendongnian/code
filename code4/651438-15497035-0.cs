    protected override void LoadViewState(object state)
    {
        base.LoadViewState(state);
        var id = this.ViewState["DynamicControlGeneration"] as string;
        if (id != null)
            GenerateDynamicControls(id);
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        this.ViewState["DynamicControlGeneration"] = id;
        GenerateDynamicControls(id);
    }
