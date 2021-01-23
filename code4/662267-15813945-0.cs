    using (MySqlConnection cn = new MySqlConnection(GetConnectionString()))
    using(MySqlCommand cmd = new MySqlCommand("insert_file", cn))
    {
        cn.Open();
        // Add the required parameters here //
        cmd.ExecuteNonQuery();
        lastInsertID = Convert.ToInt32(cmd.Parameters["@fileid"].Value);
    }
}
    
