        if (x == true)
            {
                Session["username"] = tb_email.Text;
                Session["trainer"] = trainer;
                if (Roles.IsUserInRole(tb_email.Text, "Administrator"))
                    {
                        FormsAuthentication.DefaultUrl="~/Administrator/Admin_Home.aspx";
                        FormsAuthentication.RedirectFromLoginPage(tb_email.Text, NotPublicCheckBox.Checked);
                    }
                if (Roles.IsUserInRole(tb_email.Text, "Trainer"))
                    {
                        FormsAuthentication.DefaultUrl="~/Trainer/Trainer_Home.aspx";
                        FormsAuthentication.RedirectFromLoginPage(tb_email.Text, NotPublicCheckBox.Checked);
                    }
                if (Roles.IsUserInRole(tb_email.Text, "Salon Manager"))
                    {
                        FormsAuthentication.DefaultUrl="~/Salon/Salon_Home.aspx";
                        FormsAuthentication.RedirectFromLoginPage(tb_email.Text, NotPublicCheckBox.Checked);
                    }
                if (Roles.IsUserInRole(tb_email.Text, "IT"))
                    {
                        FormsAuthentication.DefaultUrl="Home.aspx";
                        FormsAuthentication.RedirectFromLoginPage(tb_email.Text, NotPublicCheckBox.Checked);
                    }
            }
        else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
