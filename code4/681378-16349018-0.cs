    using (var connection = new SqlConnection(_sqlstring))
    {
        using (var command = new SqlCommand("GetAllEncodedMedia", connection))
        {
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        var assetItem = new MediaServices.EncodedAssets
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            PublishedName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            PublishUri = reader.IsDBNull(2) ? new Uri("http://www.null.com") : new Uri(reader.GetString(2)),
                            EncodePreset = reader.IsDBNull(3) ? 0 : (MediaServices.EncodePresetsForSmoothStreaming)reader.GetInt32(3),
                            AssetId = reader.IsDBNull(4) ? null : reader.GetString(4),
                            EncoderJobId = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                            //EncoderState = reader.IsDBNull(6) ? 0 : (JobState)reader.GetInt32(6),
                            //AssetState = reader.IsDBNull(7) ? 0 : (MediaServices.InternalAssetState)reader.GetInt32(7),
                            GroupId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                            Published = !reader.IsDBNull(2)
                        };
                        listReturn.Add(assetItem);
                    }
                }
            }
            catch (Exception ex)
            {
                //error
            }
        }
    }
