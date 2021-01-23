    string results = @"server=111.111.11.111; userid=anyone; 
        password=anypassword; database=anydatabase";
    MySqlConnection connection = new MySqlConnection(results);
    MySqlCommand command = connection.CreateCommand();
    MySqlDataReader reader;
    command.CommandText = "select * from mycustomers";
    connection.Open();
    reader = command.ExecuteReader();
    using(var sw = new StreamWriter("C:\MyPath\MyFile.txt"))
    {
        while (reader.Read())
        {
            var row = (IDataRecord)reader;
            sw.WriteLine(row["myColumn"]);
        }
    }
    connection.Close();
