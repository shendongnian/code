    try
    {
        using (var connection = new MySqlConnection(...))
        using (var adapter = new MySqlDataAdapter())
        using (var table = new DataTable())
        using (var cmd = new MySqlCommand(...))
        {
            ...
        }
    }
