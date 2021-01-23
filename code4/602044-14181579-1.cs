     protected void arabic_Click(object sender, EventArgs e)
    {
      
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
        if (Session["lang"].ToString() == "en")
        {
            string arlink= pageName.Substring(0, pageName.Length - 5) + "-ar.aspx";
            Session["lang"] = "ar";
            //
            var page = (Page)HttpContext.Current.CurrentHandler;
            string QueryString = page.ClientQueryString; // this code get The Query String 
            if (!(string.IsNullOrEmpty(QueryString)))
            {
                Response.Redirect(arlink +"?"+ QueryString);
            }
            else
            {
                Response.Redirect(arlink);
            }
        }
    
    }
    
