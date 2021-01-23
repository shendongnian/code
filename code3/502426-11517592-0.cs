     protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() != "")
            {
                //do code here
            }
            else
            {
                Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
            }
        }
