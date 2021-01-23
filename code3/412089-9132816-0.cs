    string sqlUpdate = "Update Logs set Message = @MESSAGE where ID = @ID";
    using (SqlCommand cmd = new SqlCommand(sqlUpdate, someConnection))
    {
        cmd.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.Xml)).Value = encryptedMessage;
        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = message.Id;
        cmd.ExecuteNonQuery();
    }
