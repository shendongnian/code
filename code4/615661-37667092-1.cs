    using (var command = new SqlCommand("TempInsertTable",
                        oUoW.Database.Connection as SqlConnection) { CommandType = CommandType.StoredProcedure }
                    )
    {
        command.Transaction = oUoW.Database.CurrentTransaction as SqlTransaction;
        command.Parameters.Add(new SqlParameter("@newTableType", oTempTable));
        drResults = command.ExecuteReader();
        drResults.Close();
    }
