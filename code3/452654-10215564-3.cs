    private async void Form_Load(object sender, EventArgs args)
    {
      connection = await Task.Run(() =>   // TaskEx.Run in the CTP
        {
          var sql = new SqlConnection();
          sql.ConnectionString = "your connection string";
          sql.Open();
          return sql;
        });
    }
