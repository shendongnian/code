    public class PhotosRepositorySql : IPhotosRepository
    {
        private readonly string _connectionString;
        public PhotosRepositorySql(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void GetPhoto(int photoId, Stream output)
        {
            using (var ts = new TransactionScope())
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText =
                @"
                    SELECT 
                        Photo.PathName() as path, 
                        GET_FILESTREAM_TRANSACTION_CONTEXT() as txnToken 
                    FROM 
                        PhotoAlbum 
                    WHERE 
                        PhotoId = @PhotoId
                ";
                cmd.Parameters.AddWithValue("@PhotoId", photoId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var path = reader.GetString(reader.GetOrdinal("path"));
                        var txnToken = reader.GetSqlBinary(reader.GetOrdinal("txnToken")).Value;
                        using (var stream = new SqlFileStream(path, txnToken, FileAccess.Read))
                        {
                            stream.CopyTo(output);
                        }
                    }
                }
                ts.Complete();
            }
        }    
    }
