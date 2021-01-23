    if(Page.IsPostBack)
    {
        if( Request.Form["username"] == "admin" && Request.Form["password"] ==  "password") {
                    HttpContext.Current.Session["username"] = Request.Form["username"];
                    HttpContext.Current.Session["password"] = Request.Form["password"];
                    Response.Redirect("elsewhere.html");
                }
                else {
    
                        Response.Redirect("login.aspx?errors=1");
                }
    }
