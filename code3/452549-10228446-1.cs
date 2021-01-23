     protected void Page_Load(object sender, EventArgs e)
        {
             if (Request.QueryString["action"] != null) {
                
                Session["ScreenResolution"] = Request.QueryString["res"].ToString();
                Response.Redirect("Catalogue.aspx");
            }
        }
