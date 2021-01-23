    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
             string eventTarget = Page.Request.Params["__EVENTTARGET"];
             if(whatever)
             {
                 //do your logic here
             }
        }
    }
