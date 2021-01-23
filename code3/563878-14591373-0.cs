    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.btnlinkclick.Click += new EventHandler(btnlinkclick_Click);
    }
    void btnlinkclick_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 1;
    }
