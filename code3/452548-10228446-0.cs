    if (!IsPostBack)
            {
                if (Session["ScreenResolution"] == null)
                {
                    Response.Redirect("detectscreen.aspx");
                }
                else
                {
                    Session["Screensize"] = Session["ScreenResolution"].ToString();
                }
    
    
                
                TextBox1.Text = Session["Screensize"].ToString();
            }
