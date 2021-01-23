    public string InsertWithParams(string sql, List<string> colValue, List<string> cols, out string error)
    {
         error = "";
         try
         {
             OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=)(PORT=)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=)));User Id=;Password="); 
             OracleCommand command = new OracleCommand(sql, con);
             for (int i = 0; i < colValue.Count; i++)
             {
                  command.Parameters.Add(new OracleParameter(cols[i], colValue[i]));
             }
             command.ExecuteNonQuery();
             command.Connection.Close();
        }
        catch (Exception ex)
        {
             error = ex.Message;
        }
        return null;
    }
