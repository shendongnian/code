    private void Page_Load()
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                urlReferer = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString();
            }
            else
            {
                urlReferer = "";
            }
        }
    }
