    if (Session["staffId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                 cmbActivity.DataSource = a;
                 cmbActivity.DataTextField = "activityName";
                 cmbActivity.DataValueField = "activiyId";
                }
            }
