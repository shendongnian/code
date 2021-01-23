    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtLogin.Text;
        string password = ORFunc.GetMD5Hash(txtPassword.Text);
        MySqlParameter p1 = new MySqlParameter("@uname", username);
        MySqlParameter p2 = new MySqlParameter("@pass", pass);
        string cmdText = "SELECT * FROM orUsers WHERE username = @uname AND pass = @pass"
        DataTable dt = ORFunc.GetTable(cmdText, p1, p2);
        foreach(DataRow r in dt.Rows)
        {
           Console.WriteLine(r["ID"].ToString());
        }
    }
    public static DataTable GetTable(string cmdText, params MySqlParameter[] prms)
    {
        string connString = "server=" + ORVars.sqlServerAddr + ";port=" + ORVars.sqlServerPort + ";uid=" + ORVars.sqlServerUID + ";pwd=" + ORVars.sqlServerPass + ";database=" + ORVars.sqlServerDB + ";";
        // This is the INITIALIZE part
        using(MySqlConnection conn = new MySqlConnection(connString))
        using(MySqlCommand command = new MySqlCommand(cmdText, conn))
        {
             // OPEN
             conn.Open();
             DataTable dt = new DataTable();
             command.Parameters.AddRange(prms);
             // USE
             MySqlDataReader reader = command.ExecuteReader();
             dt.Load(reader);
             return dt;
        } // The closing brace of the using statement is the CLOSE/DESTROY part of the pattern
    }
