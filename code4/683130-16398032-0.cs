     if (Request.QueryString["Logout"] != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Default.aspx", false);
            }
