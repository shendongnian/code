    protected void Page_Init(object sender, EventArgs e)
    {
        myRadioButtonList.SelectedIndexChanged += new EventHandler(rb_SelectedIndexChanged);
    }
    
    void rb_SelectedIndexChanged(object sender, EventArgs e)
    {
        myGridView.DataSource = SomeClass.GetDetails(myRadioButtonList.SelectedValue);
        myGridView.DataBind();
    }
