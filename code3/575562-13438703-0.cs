    string ConnString=(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\dxs.accdb")
    string vals = "'"+textBox1.Text+"','"+textBox1.Text+"','"+textBox1.Text+"'";
    string SqlString = "Insert Into tests(Nam,add,phone) Values ("+vals+")";
    using (OleDbConnection conn = new OleDbConnection(ConnString))
    {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
        {
            cmd.CommandText = SqlString;
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("entered");
        }
    }
