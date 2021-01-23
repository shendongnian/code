                rdr = cmdDatabase.ExecuteReader();
                while (rdr.Read()) //make sure this is added or it won't work.
                {
                if (rdr.GetBoolean("ban"))
                {
                    ////Login Login = new Login();
                    ////this.Content = Login;
                    ErrorLN.Content = "Licentie of naam incorrect.";
                }
                else
                {
                    Welkom Welkom = new Welkom();
                    this.Content = Welkom;
                }
            }
            conn.Close();
            }
