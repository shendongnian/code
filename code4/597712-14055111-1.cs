    public delegate void PreRenderDelegate(object sender, TreeView tv);
    public event PreRenderDelegate PreRender;
    public void OnPreRender(object sender, EventArgs e){
        if(this.Prerendered!=null)
            this.Prerendered(this, aTreeView);
    }
