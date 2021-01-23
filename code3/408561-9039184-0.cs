    static void Read()
    {
        using (var currentConnection = new OleDbConnection(
            "provider=MSDAORA;Data Source=orcl;User ID=db_test;Password=db_test;"))
        {
            currentConnection.Open();
            using (var myCommand = new OleDbCommand())
            {
                myCommand.Connection = currentConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "Get_Data";
                myCommand.Parameters.Add(
                    new OleDbParameter(
                        "firstParam",
                        OleDbType.Integer, 0, ParameterDirection.Input,
                        true, 0, 0, "", DataRowVersion.Default, Convert.DBNull));
                myCommand.Parameters[0].Value = 42;
                var myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                    for (int i = 0; i < myDataReader.FieldCount; i++)
                        Console.WriteLine(myDataReader.GetName(i));
            }
        }
    }
    CREATE OR REPLACE PROCEDURE Get_Data (
       p_return_cur OUT SYS_REFCURSOR,
       firstParam INTEGER) 
    IS 
    BEGIN 
      OPEN p_return_cur FOR select * from test; 
    END Get_Data;
