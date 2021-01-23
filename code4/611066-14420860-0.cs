    public List<yourobject> SearchByAlbum(string AlbumName)
    {
        List<yourobject> yourobjects = new List<yourobject>();
    
        VinylComm.CommandType = CommandType.StoredProcedure;
        VinylComm.CommandText = "AlbumVinylSearch";
    
        SqlParameter VinylAlbumName;
        VinylAlbumName = new SqlParameter();
        VinylAlbumName.ParameterName = "@AlbumName";
        VinylAlbumName.SqlDbType = SqlDbType.VarChar;
        VinylAlbumName.SqlValue = AlbumName;
        VinylAlbumName.Size = 50;
        VinylAlbumName.Direction = ParameterDirection.Input;
    
        VinylComm.Parameters.Add(VinylAlbumName);
    
        VinylConn.Open();
    
        SqlDataReader reader = VinylComm.ExecuteReader();
        while (reader.Read())
        {
            yourobjects.Add(new yourobject() { 
               //Fill values
            });
        }
        VinylConn.Close();
    
        return yourobjects;
    }
