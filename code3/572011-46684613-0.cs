    privat string _dataSource = @"H:\Ik.db";
    private SQLiteConnection _connection;
    private SQLiteCommand _command;
    private void connectToSQLite()
    {
        using (SQLiteConnection _connection = new SQLiteConnection())
        {
            if (File.Exists(@"H:\Ik.db"))
            {
                _connection.ConnectionString = $"Data Source={_dataSource};Version=3";
                _connection.Open();
                using (SQLiteCommand _command = new SQLiteCommand())
                {
                    _command.Connection = _connection;
                       _command.CommandText = "INSERT INTO Customer(id, Lastname,firstname,Code,City) " +
                        $"VALUES(NULL, '{txt_Lastname.Text}', '{txt_name.Text}', '{ txt_code.Text}', '{ txt_city.Text}')";
                    try
                    {
                        _command.ExecuteNonQuery();
                        MessageBox.Show($"You Connected to local Data Base under {_dataSource} Sucssefuly");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                SQLiteConnection.CreateFile(@"H:\Ik.db");
            }
        }
    }
