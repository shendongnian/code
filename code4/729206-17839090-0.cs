    private void AddDocument(string photoFilePath)
        {
            //GetFileStream() is a custom function that converts the doc into a stream
            byte[] photo = GetFileStream(photoFilePath);
            var conn = new SqlConnection(@"ConnectionString here");
            var updPhoto = new SqlCommand("UPDATE DT_Document "
                       + "SET DocumentData = @Photo WHERE Id=399", conn);
            updPhoto.Parameters.Add("@Photo", SqlDbType.Image, photo.Length).Value = photo;
            conn.Open();
            updPhoto.ExecuteNonQuery();
            conn.Close();
        }
