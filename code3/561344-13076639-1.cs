    // Create the delete query
    string sql = @"delete from GuestBook where id = @id";
    using (SqlConnection conn = dal.connectDatabase()) {
    
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
    
        try {
            conn.Open();
            cmd.ExecuteScalar();
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
