     using(var conn = new OracleConnection(Settings.Default.OraWUConnString))
                { 
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "for_temporary_testing.select_card_transaction";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Return value parameter has to be added first !
                    var Quantity = new OracleParameter();
                    Quantity.Direction = ParameterDirection.ReturnValue;
                    Quantity.OracleDbType = OracleDbType.Int32;
                    cmd.Parameters.Add(Quantity);
                    
                    //now add input parameters
                    var TransID = cmd.Parameters.Add("trans_id", TransactionID);
                    TransID.Direction = ParameterDirection.Input;
                    TransID.OracleDbType = OracleDbType.NVarchar2;
                     
                    var UsrID = cmd.Parameters.Add("usr_id", UserID);
                    UsrID.Direction = ParameterDirection.Input;
                    UsrID.OracleDbType = OracleDbType.Int32;
                    
                    cmd.ExecuteNonQuery();
    
                    conn.Close();
                    return Convert.ToInt32(Quantity.Value);
                }
