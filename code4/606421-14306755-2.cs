            rdr = cmdDatabase.ExecuteReader();
            if (rdr.HasRows)
            {
            }
            else
            {
                ErrorLN.Content = "Licentie of naam incorrect.";
                return;
            }
            while (rdr.Read()) //Make sure this is added or it won't work.
            {
                if (rdr.GetBoolean("ban"))
                {
                    ErrorSuspend.Text = "Uw licentie is verlopen of geblokeerd.                      Contacteer uw verdeler om een nieuwe licentie te bekomen.";
                    return;
                }
                else
                {
                    Login Login = new Login();
                    this.Content = Login;
                }
            }
