    if (!IsPostBack)
    {
        if (!(bool)Session["popupsChecked"])
        {
            Page.Header.Controls.Add(new LiteralControl("<script src=\"/js/popupCheck.js\" type=\"text/javascript\"></script>"));
        }
    }
