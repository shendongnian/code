    string connstr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;User Instance=True";
    
    using(SqlConnection conn = new SqlConnection(connstr))
    {
      using (SqlCommand comm = new SqlCommand(conn))
      {
        comm.CommandText = "INSERT INTO tbl (name, family, image) VALUES (@name,@family,@Content)";
        comm.Parameters.Add(new SqlParameter("name",DbType.String,"Fred"));
        comm.Parameters.Add(new SqlParameter("family",DbType.String,"Flintstone"));
        using(FileStream fs = new FileStream("FredWilmaBamBamAndDino.jpg",FileMode.Open,FileAccess.Read))
        {
          comm.Parameters.Add(new SqlParameter("content",DbType.Image,fs));
        }
        cmd.ExecuteNonQuery();
      }
    }
