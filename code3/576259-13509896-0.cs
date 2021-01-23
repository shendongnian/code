        string list = string.Join("', '", f);
        string l = "'" + list + "'";
        string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtDB.Text + "";
        string ComStr = "UPDATE Contacts SET Category = @Category where [E-mail Address] in (" + l + ")";
        using (OleDbConnection con = new OleDbConnection(ConnStr))
        {
            con.Open();
            using (OleDbCommand com = new OleDbCommand(ComStr, con))
            {
                
                com.Parameters.AddWithValue("Category", "Не получава мейли");
                com.ExecuteNonQuery();
            }
            con.Close();
        } 
