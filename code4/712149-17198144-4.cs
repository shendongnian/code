    string ConString = "Use your database address";
    string CmdString = string.Empty;
    using (SqlConnection con = new SqlConnection(ConString))
    {
        CmdString = "SELECT * FROM Fee";
        SqlCommand cmd = new SqlCommand(CmdString, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable("Fee");
        sda.Fill(dt);
        datagrid1.ItemsSource = dt.DefaultView;
     }
