        protected void english_Click(object sender, EventArgs e)
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
        if (Session["lang"].ToString() == "ar")
        {
            string enlink = pageName.Substring(0, pageName.Length - 8) + ".aspx";
            Session["lang"] = "en";
            var page = (Page)HttpContext.Current.CurrentHandler;
            string QueryString = page.ClientQueryString;
            if (!(string.IsNullOrEmpty(QueryString)))
            {
                Response.Redirect(enlink + "?" + QueryString);
            }
            else
            {
                Response.Redirect(enlink);
            }
        }
    }
   
