    //First Change : I have tested with following connection String and it worked perfectly
    string ConnString=@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\dxs.accdb";
    
    string sql="Insert Into tests([Nam],[add],[phone]) Values (@Nam,@add,@phone)";
    // Correction 1: Above line is changed ?,?,? to parameter names (names used by your command)
    using (OleDbConnection conn = new OleDbConnection(ConnString))
    {
       using (OleDbCommand cmd = new OleDbCommand(sql, conn))
       {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("@Nam", textBox1.Text);
          cmd.Parameters.AddWithValue("@add", textBox2.Text);
          cmd.Parameters.AddWithValue("@phone",textBox3.Text);
          // Correction 2: your parameter names are changed @"xyz" to "@xyz"
    
          conn.Open();
          cmd.ExecuteNonQuery();
          MessageBox.Show("entered");
       }
    }
