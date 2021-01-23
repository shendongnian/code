    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["JSChecked"] == null)
        //JSChecked -indicates if it tried to run the javascript version
        {
            // prevent infinite loop
            Session["JSChecked"] = "Checked";
            string path = Request.Url + "?JScript=1";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", 
              "window.location.href='" + path + "';", true);
        }
        if (Request.QueryString["JScript"] == null)
            Response.Write("JavaScript is not enabled.");
        else
            Response.Write("JavaScript is enabled.");
    }
