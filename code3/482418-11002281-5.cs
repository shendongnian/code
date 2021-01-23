    protected void Page_Load(object sender, EventArgs e)
    {
        this.myuserControl.Update += new MyUserControlUpdateEventHandler(myuserControl_Update);
    }
    
    void myuserControl_Update(object sender, MyuserControlEventArgs e)
    {
        this.parentDiv.visible = !e.ShouldHideUI;
    }
