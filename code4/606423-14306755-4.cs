            if (rdr.HasRows)
            {
                while (rdr.Read()) //Make sure this is added or it won't work.
                {
                    if (rdr.GetBoolean("ban"))
                    {
                        ErrorSuspend.Text = "Uw licentie is verlopen of geblokkeerd.                      Contacteer uw verdeler om een nieuwe licentie te bekomen.";
                        return;
                    }
                    else
                    {
                        Login Login = new Login();
                        this.Content = Login;
                    }
                }
            }
            else
            {
                ErrorLN.Content = "Licentie of naam incorrect.";
                return;
            }
        }
