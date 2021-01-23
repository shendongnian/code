    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.Page.ClientScript.GetPostBackEventReference(clickMe, "");
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["__EVENTTARGET"] == "clickMe")
        {
            ClickMeOnClick();
        }
    }
