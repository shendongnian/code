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
      command.Parameters.AddWithValue("@VericiKB", "VericiKB");//pass a variable here 
      SqlParameter param1 = command.Parameters.AddWithValue("@HucreKB", "HucreKB");//pass a variable here
      SqlParameter param2 = command.Parameters.AddWithValue("@OrtamKB", "OrtamKB");//pass a variable here
      param1.SourceVersion = DataRowVersion.Original;
      param2.SourceVersion = DataRowVersion.Original;
      //what is this ..??? da.UpdateCommand = command;
      command.ExecuteNonQuery;
     }
     catch (Exception e)
     {
        //Write or trap your exception here..
     }
