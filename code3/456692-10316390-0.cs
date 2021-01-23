    ContentPlaceHolder mpContentPlaceHolder;
    Panel pn;
    mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("PHMainBlock");
    if(mpContentPlaceHolder != null)
    {
        pn = (Panel) mpContentPlaceHolder.FindControl("NormalUser");
        pn.Visible = false;
    }
