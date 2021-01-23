     void SetDate(int recordID, datetime timeStamp)
     {
        string SQL = "UPDATE [sometable] SET someDateTimeColumn= @NewTime WHERE ID= @ID";
        using (var cn = new SqlCeConnection("connection string here"))
        using (var cmd = new SqlCeCommand(SQL, cn))
        {
            cmd.Parameters.Add("@NewTime", SqlDbType.DateTime).Value = timeStamp;
            cmd.Parameters.Add("@ID", SqlDbType.Integer).Value = recordID;
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    } 
