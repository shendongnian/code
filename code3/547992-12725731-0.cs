    using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SimpeltForumConnectionString"].ConnectionString)) {
        con.Open();
        int newID;
        var sql = "INSERT INTO TraadTabel VALUES (@TradNavn, @KategoriID);SELECT CAST(scope_identity() AS int);";
        using (var insertCommand1 = new SqlCommand(sql, con)) {
            insertCommand1.Parameters.AddWithValue("@TradNavn", TradNavn);
            insertCommand1.Parameters.AddWithValue("@KategoriID", KategoriID);
            newID = (int)insertCommand1.ExecuteScalar();
        }
        sql = "INSERT INTO Beskeder VALUES (@Besked, @newID, @BrugerNavn);";
        using (var insertCommand2 = new SqlCommand(sql, con)) {
            insertCommand2.Parameters.AddWithValue("@newID", newID);
            insertCommand2.Parameters.AddWithValue("@Besked", Besked);
            insertCommand2.Parameters.AddWithValue("@BrugerNavn", BrugerNavn);
            var affectedRecords = insertCommand2.ExecuteNonQuery();
        }
    }
