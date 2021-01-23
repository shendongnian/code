    string sql = "INSERT INTO dbo.Language VALUES(@languageID, @languageName);";
    using (var con = new SqlConnection(yourConnectionString))
    using(var cmd = new SqlCommand(sql, con))
    {
        con.Open();
        foreach (ListItem item in lbLanguagesKnown.Items)
        {
            cmd.Parameters.Clear();
            if (item.Selected)
            {
                cmd.Parameters.AddWithValue("@languageID", int.Parse(item.Value));
                cmd.Parameters.AddWithValue("@languageName", item.Text);
                int insertedCount = cmd.ExecuteNonQuery();
            }
        }
    }
