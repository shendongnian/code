    using (OleDbConnection connection = new OleDbConnection(db.konek()))
    {
       try
       {
           connection.Open();
           ....
           ....
       }
       catch (Exception ex)
       {
           ....
       }
    }
