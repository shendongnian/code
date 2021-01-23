    protected void Page_Load(object sender, EventArgs e)
    {
        myRepeater.ItemDataBound += new RepeaterItemEventHandler(myRepeater_ItemDataBound);
        myRepeater.DataSource = new int[3];
        myRepeater.DataBind();
    }
    void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var textbox = e.Item.FindControl("myTextBox");
        textbox.ClientIDMode = ClientIDMode.Static;
        textbox.ID = "myTextBox" + (e.Item.ItemIndex + 1);
    }
