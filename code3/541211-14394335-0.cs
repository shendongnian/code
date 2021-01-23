            if (!IsPostBack)
            {
                if (Session["Navigation"] == null)
                {
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    Response.Redirect("~/Login.aspx");
                }                                                                               protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            
            Session["Navigation"] = null;
            Session.Abandon();
          
            Response.Redirect("~/Login.aspx");
        }                                                                                             but it's not working.It still redirects to prevoios page after click on back button
