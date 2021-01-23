    using (SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress;
                         Integrated Security=SSPI;MultipleActiveResultSets=true"))
    {
      con.Open();
      using (SqlCommand com = new SqlCommand(string.Empty, con))
      {
        string blah = @"declare @note varchar(1000) 
          set @note = 'asdf' 
          select @note";
        com.CommandText = blah;
        com.ExecuteReader();
      }
    }
