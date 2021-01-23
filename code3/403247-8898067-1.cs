    SqlCommand command = null;
    try
    {
      if (con.State == ConnectionState.Closed)
      {
          con.Open();
      }
      string updateQuery = @"UPDATE Hucre set VericiKB=@VericiKB 
             WHERE OrtamKB=@OrtamKimlikBilgisi and HucreKB=@HucreKB";
      command = new SqlCommand(updateQuery, con);
      command.Parameters.Add("@VericiKB", "VericiKB");
      SqlParameter param1 = command.Parameters.Add("@HucreKB", "HucreKB");
      SqlParameter param2 = command.Parameters.Add("@OrtamKB", "OrtamKB");
      param1.SourceVersion = DataRowVersion.Original;
      param2.SourceVersion = DataRowVersion.Original;
      //what is this ..??? da.UpdateCommand = command;
      command.ExecuteNonQuery;
     }
     catch (Exception e)
     {
        //Write or trap your exception here..
     }
