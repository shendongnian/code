         using(NpgsqlConnection mycon = new NpgsqlConnection())
          {
            using(NpgsqlCommand cmd = new NpgsqlCommand())
            {
                  string connstring = String.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};timeout=1000;CommandTimeout=120;", tbHost, tbPort, tbUser, tbPass, tbDataBaseName);
                  mycon.ConnectionString = connstring;
                  cmd = mycon.CreateCommand();
                 cmd.CommandText = Query;
                  mycon.Open();
                cmd.ExecuteNonQuery();
           }
         }
}
