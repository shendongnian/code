    public MySqlDataReader Consulta(String sql){
                string connectionString = "Server=***;Port=3306;Database=****;UID=***;Pwd=****;pooling=false";
       var conn = new MySqlConnection(connectionString);
       conn.Open();
       var cmd = new MySqlCommand(sql,conn);
       var rs =cmd.ExecuteReader();
       return (rs);
    }
