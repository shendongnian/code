    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataAdapter returnVal = new MySqlDataAdapter(query,connection);
    DataTable dt = new DataTable("CharacterInfo");
    returnVal.Fill(dt);
    this.CloseConnection();
    return dt;
