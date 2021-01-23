    if (!Page.IsPostBack)
    {
        if (Page.RouteData.Values["EventID"] != null)
        {
            int eventID = Convert.ToInt32(Page.RouteData.Values["EventID"]);
        }
    }
