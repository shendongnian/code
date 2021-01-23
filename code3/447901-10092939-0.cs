    public static void Confirm(string text)
    {
        var page = (Page)HttpContext.Current.Handler;
        var uiConfirm = new HtmlGenericControl("div")
        {
            ID = "uiNotify",
            InnerHtml = text
        };
        uiConfirm.Attributes.Add("class", "ui-confirm");
        Control placeHolder = page.Master.FindControl("PlaceHolder1");
        placeHolder.Controls.Clear();
        placeHolder.Controls.Add(uiConfirm);
    }
