            string XML = "XML Data";
            OracleCommand cmd = OraConnection.CreateCommand();
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IBS.BNT_EQ.LOAD_BL_REQ_2";
            OracleParameter result = new OracleParameter();
            result.ParameterName = "P_XML";
            result.OracleDbType = OracleDbType.Clob;
            result.Value = XML;
            result.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(result);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            string str = (result.Value as OracleClob).Value;
            MessageBox.Show("Val: " + str);
            OraConnection.Close();
