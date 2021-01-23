    int amt;  
    using (var con = new SqlConnection(ConnectionString)) {
        var sql = "SELECT SUM(ItemRate) FROM logs WHERE RoomNo = @RoomNo";
        using (var cmd = new SqlCommand(sql, con)) {
            cmd.Parameters.AddWithValue("@RoomNo", Int32.Parse(txtRoom.Text));
            con.Open();
            amt = (int)cmd.ExecuteScalar();
        }
    }
