     SqlParameter[] parameters = new SqlParameter[]
                                 {
                                     new SqlParameter("@username", txtusername.Text),
                                     new SqlParameter("@pwd", txtpassword.Text)
                                 };
    SqlCommand cmd = new SqlCommand("SELECT username,password FROM Admin WHERE username=@username and password=@pwd", con);
    cmd.Parameters.AddRange(parameters);
