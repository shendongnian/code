    int id = 1;
    string title = "Title with ů";
    // ^^ probably coming from C# parameters
    using(var sqlcomLoggedIn = new SqlCommand(
        "UPDATE Table SET title = @title WHERE id = @id", sqlCon, sqlTrans))
    {
        sqlcomLoggedIn.Parameters.AddWithValue("id", id);
        sqlcomLoggedIn.Parameters.AddWithValue("title", title);
        int status = sqlcomLoggedIn.ExecuteNonQuery();
    }
    
