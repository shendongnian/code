        if (Request.QueryString["ReturnUrl"] != null) 
        {
            //redirect to the return url
            FormsAuthentication.RedirectFromLoginPage(userName.Text, NotPublicCheckBox.Checked);
        }
        /* create authentication cookie */
        FormsAuthentication.SetAuthCookie(tb_email.Text, NotPublicCheckBox.Checked)
        Session["username"] = tb_email.Text;
        Session["trainer"] = trainer;
        /*redirect depending on roles*/
        if (Roles.IsUserInRole(tb_email.Text, "Administrator"))
        {
            Response.Redirect("~/Administrator/Admin_Home.aspx");
        }
        if (Roles.IsUserInRole(tb_email.Text, "Trainer"))
        {
            Response.Redirect("~/Trainer/Trainer_Home.aspx");
        }
        if (Roles.IsUserInRole(tb_email.Text, "Salon Manager"))
        {
            Response.Redirect("~/Salon/Salon_Home.aspx");
        }
        if (Roles.IsUserInRole(tb_email.Text, "IT"))
        {
            Response.Redirect("Home.aspx");
        }
    }
    else
    {
        /*Login error*/
        FormsAuthentication.RedirectToLoginPage();
    }
