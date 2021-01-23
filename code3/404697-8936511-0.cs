    private bool DBConnection(string userName, string password)
    {
     SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //string cmdString = ("SELECT UserName, Password FROM Users WHERE UserName ='" + userName +
    //                    "'AND Password ='" + password + "'");         //REMOVED AS THIS IS PRONE TO SQL INJECTIONS
    string cmdString = ("SELECT * FROM Users WHERE UserName = @uname AND Password = @pw");
    SqlCommand cmd = new SqlCommand(cmdString, conn);
    cmd.Parameters.Add("uname", SqlDbType.VarChar).Value = userName;
    cmd.Parameters.Add("pw", SqlDbType.VarChar).Value = password;
    DataSet loginCredentials = new DataSet();
    SqlDataAdapter dataAdapter;
    try
    {
        if (conn.State.Equals(ConnectionState.Closed))
        {
            conn.Open();
            dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(loginCredentials);
            conn.Close();
            if (loginCredentials != null)
            {
                if (loginCredentials.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    lblMessage.Text = "Incorrect Username or Password";
                    lblMessage.Visible = true;
                }
            }   
        }
    }
    catch (Exception err)
    {
        lblMessage.Text = err.Message.ToString() + " Error connecting to the Database // " + cmd.Parameters.Count;
        lblMessage.Visible = true;
        return false;
    }
    return false;
    }
