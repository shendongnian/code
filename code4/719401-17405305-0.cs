    using (MySqlCommand bb = new MySqlCommand("UPDATE  members SET  Begin = 1 WHERE id = @id;"))
    {
        bb.Parameters.AddWithValue("@id", uid);
        bb.Connection = con;
        con.Open();
    
        bb.ExecuteNonQuery();
    
        using (MySqlCommand fff = new MySqlCommand("UPDATE  members SET  b = 1 WHERE id = @id;"))
        {
            fff.Parameters.AddWithValue("@id", uid);
            fff.Connection = con;
            
            fff.ExecuteNonQuery();
        }
        
        this.Hide();
        Main main = new Main();
        main.Show();
    }
