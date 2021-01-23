    string connStr = "server=localhost;user=root;database=........";
    using(MySqlConnection conn = new MySqlConnection(connStr))
    {
         MySqlBulkLoader bl = new MySqlBulkLoader(conn);
         bl.TableName = "yourdestinationtable";
         bl.FieldTerminator = "\t";
         bl.LineTerminator = "\n";
         bl.FileName = "path_to_your_comma_separated_value_file";
         try
         {
            conn.Open();
            int count = bl.Load();
         }
    }
