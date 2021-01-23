    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    int RETURN_VALUE_BUFFER_SIZE = 32767; 
    OracleCommand cmd = new OracleCommand();
    try {
        cmd.Connection = conn;
        cmd.CommandText = "KRIST.f_Login";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("returnVal", OracleDbType.Varchar2, RETURN_VALUE_BUFFER_SIZE);  
        cmd.Parameters["returnVal"].Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add("userName", OracleDbType.Varchar2);
        cmd.Parameters["userName"].Value = "kristian";
        cmd.Parameters.Add("password", OracleDbType.Varchar2);
        cmd.Parameters["password"].Value = "kristian";
        cmd.ExecuteNonQuery();
        string bval = cmd.Parameters["returnVal"].Value.ToString();
        return bval;
    } catch (Exception e) {
        // deal with exception 
    } finally {
        command.Dispose();
        connection.Close();
        connection.Dispose();
    }
