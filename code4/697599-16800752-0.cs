    protected void Page_Init(object sender, EventArgs e)
    {
        this.Page.Init += PageInit;
    }
    protected void PageInit(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.ControlToCompare))
        {
            this.Controls.Remove(this.compareValidator);
            this.Parent.Controls.Add(this.compareValidator);
        }
    }
