     public bool check()
     {
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volodia\Documents\WebSiteDatabase.accdb";
        using(OleDbConnection con = new OleDbConnection(conString)
        {
            con.Open();
            string commandstring = "SELECT count(*) as cntUser FROM [User] " + 
                                   "WHERE login = ? AND [password] = ?";
            using(OleDbCommand cmd = new OleDbCommand(commandstring, con))
            {
                cmd.Parameters.AddWithValue("@p1", TextBox1.Text); 
                cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
                int result = (int)cmd.ExecuteScalar();
                if(result > 0)
                   return true;
            }
        }
        return false;
    }
