    protected void bonus_load(object sender, EventArgs e)
    {
        string previousPage = HttpContext.Current.Request.UrlReferrer.AbsolutePath;
        if (previousPage == "/page1.aspx")
        {
            //Do Something
        }
        else if (previousPage == "/page2.aspx")
        {
            //Do Other Things
        }
      }
