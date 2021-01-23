    string sql = "your SELECT command here";
    string connectionString = "Server=localhost;Port=3306;Database=projecttt;" +
                             "UID=root;Pwd=techsoft;pooling=false";
    using(MySqlConnection conn = new MySqlConnection(connectionString))
    {
         conn.Open();
         using(MySqlCommand cmd = new MySqlCommand(sql,conn))
         {
              using(MySqlDataReader rs =cmd.ExecuteReader())
              {
                   total = conexiondb.countRec("price", "processeddata_table");
                   string json;
                   json = json + "{\n";
                   json = json + " \"page\":\""+intpage+"\",\n";
                   json = json + "\"total\":"+total_pages+",\n";
                   json = json + "\"records\":"+total+",\n";
                   json = json + "\"rows\": [";
                   rc =false;
                   while(rs.Read())
                   {
                      .....
                   }
               }
           }
       }
