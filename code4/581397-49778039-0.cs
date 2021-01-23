    private string AppendOracleCountOrNothing(StringBuilder sql)
    {
        if (_myProvider == Providers.Oracle)
            sql.AppendLine("rowCnt := rowCnt + SQL%ROWCOUNT;");
    }
    public void SomeMethod()
    {
        var longSqlChain = new StringBuilder(2000);
        longSqlChain.Append("Insert into table...;");
        AppendOracleCountOrNothing(longSqlChain);
        if (someCondition)
        {
            longSqlChain.AppendLine("Update anotherTable...;");
            AppendOracleCountOrNothing(longSqlChain);
        } 
        // may be, add some more sql to longSqlChain here....
       
        int rowsAffected;
        if (_myProvider == Providers.Oracle)
        {
            longSqlChain.Insert(0, @"DECLARE
                rowCnt number(10) := 0
                BEGIN
                ").AppendLine(@":1 := rowCnt;
                END;");
            // Now, here we have some abstract wrappers that hide provider specific code. 
            // But the idea is to prepare provider specific output parameter and then parse its value
            var p = ParameterWrapper.PrepareParameter(":1", 0, ParameterDirection.Output, myProvider);
            SqlExecWrapper.ExecuteNonQuery(_myProvider, CommandType.Text, sql, new[]{p});
        }
        else // sql server
        {
            rowsAffected = SqlExecWrapper.ExecuteNonQuery(_myProvider, CommandType.Text, sql, null);
        }
    }
