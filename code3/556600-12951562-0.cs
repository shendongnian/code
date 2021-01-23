    using(cnn = new SQLiteConnection(dbConnection))
    {
         cnn.Open();
         this.ExecuteNonQuery("...your query");
    }
