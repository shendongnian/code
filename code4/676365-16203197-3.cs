    public int ExecuteNonQuery(string sqlCommand, ExecutionTypes executionType)
    {
        int num6;
        this.CheckDisconnected();
        int statementsToReverse = 0;
        int num2 = 0;
        StringCollection strings = this.GetStatements(sqlCommand, executionType, ref statementsToReverse);
        ........
