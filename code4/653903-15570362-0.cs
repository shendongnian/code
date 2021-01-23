    private string Read_MDB_Acc(String acc)
        {   string myReturn = string.Empty;
            ...
            while (odrReader.Read())
                            {                            
                                myReturn = odrReader["acc"].ToString();
    
    
                            }
    
    
                            odrReader.Close();
    
                            odcConnection.Close();
                            return myReturn;
        }
      
