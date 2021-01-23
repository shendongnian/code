    var data = ImageToByteArray(pictureBox.Image);
    using (var cmd = new MySqlCommand("INSERT INTO itemimage SET imageName = @image",
                                      _con))
    {
        cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = data;
        cmd.ExecuteNonQuery();
    }
    
