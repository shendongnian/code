    using (SqlCeConnection sqlConn = new SqlCeConnection("Your ConnectionString"))
    {
      sqlConn.Open();
    
      using (SqlCeCommand sqlComm = new SqlCeCommand("Vaccinations WHERE [City Tag Number] = (@CityTagNumber)", sqlConn))
      {
        sqlComm.Parameters.AddWithValue("@CityTagNumber", originalCTag);
        sqlComm.ExecuteNonQuery();
      }
    }
