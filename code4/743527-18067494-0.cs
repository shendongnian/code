    using (var scope = new TransactionScope())
    using (var con = getcon())
    using (var cmd = new SqlCommand("UPDATE SomeTable SET Column1 = 'test'", con))
    {
        throw new Exception("Oops");//Throw excception somewhere here             
        cmd.ExecuteNonQuery();
        scope.Complete();
    }
