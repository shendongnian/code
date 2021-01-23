    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            myGv.DataBind();
        }
        else
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
            if (!Request["__EVENTARGUMENT"].Contains("Page$"))
            {
                 reBind(Request["__EVENTARGUMENT"]);
            }
        }
    }
