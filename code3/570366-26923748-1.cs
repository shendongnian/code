    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(this);
        if (!Page.IsPostBack)
        {
            div1.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this, "ClickDiv");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text += "1";
        UpdatePanel1.Update();
    }
    protected void Div1_Click()
    {
        div1.InnerHtml += "b";
        UpdatePanel1.Update();
    }
    public void RaisePostBackEvent(string eventArgument)
    {
        if (!string.IsNullOrEmpty(eventArgument))
        {
            if (eventArgument == "ClickDiv")
            {
                Div1_Click();
            }
        }
    }
}
