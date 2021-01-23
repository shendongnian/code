    var str = INSERT INTO Table_01(ID,Comment,DateTimeStamp)     
    VALUES(@ID,@Comment,GetDate())
    using (var cmd = new SqlCommand(str, con))
    {
    cmd.Parameters.Add(new SqlParameter("@ID", Guid.NewGuid()));
    cmd.Parameters.Add(new SqlParameter("@Comment", CaseComment));
    cmd.ExecuteNonQuery();
    }
